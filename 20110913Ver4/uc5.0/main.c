/*Version:	TMU1.1b
  
  The Project is AT89C51RC2 Based project, it measures the width of the pulse (mas = 100msec)
  using Programmable Counter Arrays (PCA).The LCD 8 bit Interface with Busy Flag Technique is
  incorporated for display. The results can either be display on LCD, or being logged  to  PC
  serially at the buadrate of 19200. A button is used to make the system Ready.
 
  Programmer:	Sajjad Hussain, SE, SDPD, ICCC, 12-11-2008.

  Simulted: 	Proteus 7.0
  
  Crystal	22118400
  Serial BaudRate 	19200 clocked at 22118400
  Timers					clocked at 22118400
  PCA Timers			clocked at 614400	(Timer0  22118400/12/3)
  Measureable Time	106.7ms

  
  Modified:	12-12-2010
  
    PCA Timers			clocked at 460800	(Timer0  22118400/12/4)
    Measureable Time	  142.2ms
    
  Start Pulse                              ____________________
  																					|
  																					|
  																					|_____________________________________
  Stop Pulse 1                         		     							 ____________________
  																							|
  																							|
							   		_______________________________________|
  Stop Pulse 1  	 	                      		     							 ____________________
	  																							|
  																								|
							   			_______________________________________|

  Modified: 06-07-2011
  	PCA 0-3			Stop Channels
  	PCA 4				Start Channel
  	One Digit after Decimal Point
  	Serial Port Removed
*/
#include "at89c51rc2.h"
#define Putc LcdWriteChar

//Pins Assignments
sbit BKLT = P2^4;//3; 
sbit RS  = P2^2;//4; 
sbit RW  = P2^5;
sbit EN  = P2^3;//6;
sbit LED = P2^7;
sbit BS  = P0^7;

unsigned char Key1,Key2,i,g;
bit isInit=0,finish;
idata unsigned int Stop[4];
char cnt=0;
unsigned char s=0;
idata char Chan1[20];
idata char Chan2[20];
idata char Chan3[20];
idata char Chan4[20];
//Function Prototypes
void LcdInit();
void DelayUs(void);
void DelayMs(void);
void Delay1Ms(void);
void Delay10Ms(void);
void LcdClear(void);
void LcdWriteStr(char *var);
void LcdWriteCmd(unsigned char c);
void LcdWriteChar(unsigned char var);
void LongToAscii(unsigned long Value);
void SendChar(unsigned char c);
void SendStr(char *s);
void LcdGotoXY(unsigned char r,unsigned char c);
void Convert(unsigned long PulseWidth,char *ss, unsigned char Channel);

// Main Program Starts Here
void main()
{
	// Configure the Serial Port
	// Initialize 8051 registers
   SCON 		= 0x40;//0x50;			 // REN = 0;
   BDRCON 	&=0xEC;               // BRR=0; SRC=0;
   BDRCON 	|=0x0C;               // TBCK=1;RBCK=1; SPD=0
   BRL		=0xFA;                // =-6 for 9600 Bds at 22.1184MHz
   BDRCON 	|=0x10;               // Baud rate generator run
   ES = 0;
   
   // Set Priority of PCA Highest
	IPH0 = 0x40;
	IPL0 = 0x40;
	// Set External Interrupt Settings
	EX0 = 1;
	IT0 = 1;
	// Set Timer0 used as Clock for PCA
	TMOD = 0x12;
	TL0  = 0xFC;// Divide by 4
	TH0  = 0xFC;// 
	TR0  = 1;
        
	// Set PCA Module and PCA Interrupt
	CCON = 0x00;// stop timre, clear flags
	CMOD = 0x04;// PCA Count Pulse Select
	CH = 0;CL = 0; // Clear PCA Timer Registers
	CCAPM0 = 0;	//Positive Edge Stop Pulse 1
	CCAPM1 = 0;	//Positive Edge Stop Pulse 2
	CCAPM2 = 0;	//Positive Edge Stop Pulse 3
	CCAPM3 = 0; //Positive Edge Stop Pulse 4
	CCAPM4 = 0; //Negative Edge Start Pulse

	LED = 0;
	// Enable Interrupts
	//IEN0 = IEN0 | 0xC1;
	EC = 1;
	EA = 1;
   
   
	

	LcdInit();
	LcdGotoXY(1,3);
	LcdWriteStr("Time  Measuring");
	LcdGotoXY(2,3);
	LcdWriteStr(" Unit (TMU-01)");	
	LcdGotoXY(3,3);
	LcdWriteStr("Range: 1-135ms");
   // Initial Screen
	isInit = 1;
	
	//Running Forever
	while(1)
	{
		// For Local LCD Display
		if(finish)
		{
			finish = 0;
			LED = 0;
			LcdClear();
			
			// Channel 1
			LcdGotoXY(1,2);
			Convert(Stop[0],Chan1,1);
			LcdWriteStr(Chan1);
 		 	// Channel 2
			LcdGotoXY(2,2);
 		 	Convert(Stop[1],Chan2,2);
 		 	LcdWriteStr(Chan2);
	 		// Channel 3
			LcdGotoXY(3,2);
	 		Convert(Stop[2],Chan3,3);
	 		LcdWriteStr(Chan3);
	 		// Channel 4
			LcdGotoXY(4,2);
	 		Convert(Stop[3],Chan4,4);
	 		LcdWriteStr(Chan4);
	 		// Send to Serial Port
	 		SendStr("Unit (TMU-01)");
	 		SendStr("====");
	 		SendStr(Chan1);
	 		SendStr(Chan2);
	 		SendStr(Chan3);
	 		SendStr(Chan4);
	 		SendStr("====");
		}//finish
	}//while
}//main

// Interrupt Routines
void PCATimers() interrupt 6  using 1
{
	if(CF)
	{
		CCON = 0x00; // Stop Timer, Clear CF Flag
	 	CMOD = 0x04;
	 	finish = 1;
	}//Cf
	//Start Pulse
	if(CCF4)
	{
		CCF4 = 0;
		CCAPM4 = 0x00;				// Disable ECCFn bit
		
		CCAPM0 = 0x11; 			//Negative Edge	Stop Pulse 1
		CCAPM1 = 0x11;				//Negative Edge	Stop Pulse 2
		CCAPM2 = 0x11;				//Negative Edge	Stop Pulse 3
		CCAPM3 = 0x11; 			//Negative Edge	Stop Pulse 4
		CL =0; CH =0;				// Reset the Timer Registers
		CMOD = 0x05;				// Enable Overflow Interrupt
		CR = 1;						// Run PCA Timer
	}
	//Stop Pulse 4
	if(CCF0)
	{
		CCF0 = 0;
 		Stop[3] = CCAP0L | (CCAP0H<<8);
 		CCAPM0 = 0x00;
	}
	//Stop Pulse 3
	if(CCF1)
	{
		CCF1 = 0;
		Stop[2] = CCAP1L | (CCAP1H<<8);
		CCAPM1 = 0x00;
	}
	//Stop Pulse 2
	if(CCF2)
	{
		CCF2 = 0;
 		Stop[1] = CCAP2L | (CCAP2H<<8);
		CCAPM2 = 0x00;
	}
	//Stop Pulse 1
	if(CCF3)
	{
		CCF3 = 0;
		Stop[0] = CCAP3L | (CCAP3H<<8);
 		CCAPM3 = 0x00;
	}	
}

void KeyInt() interrupt 0 
{  
	if(isInit)
	{
		DelayMs();
		DelayMs();
		DelayMs();
		LcdClear();
		LcdGotoXY(2,4);
		LcdWriteStr("TMU Ready");
		LED = 1;
		Stop[0] = 0;
		Stop[1] = 0;
		Stop[2] = 0;
		Stop[3] = 0;
		CL =0;CH =0;
		CCON = 0x00;// stop timre, clear flags
		CMOD = 0x04;// PCA Count Pulse Select
		CCAPM4 = 0x21;	//Positive Edge Start Pulse
	}//if Init
}

// Function Definitions
void Convert(unsigned long pw, char *ss, unsigned char chn)
{
	char Q;
	long wPart,fPart;
	// Convert PulseWidth in XXX.X format
	*ss = 0x00;
	*ss = 'C';*ss++;
	*ss = 'h';*ss++;
	*ss = '#';*ss++;
	*ss = chn+48;*ss++;
	*ss = ':';*ss++;
	*ss = ' ';*ss++;
   
	if(pw<0xFC00)//140
	{
		pw = pw *10;
		wPart = (pw/4608);

		fPart = (pw - (wPart*4608));
		fPart = (fPart*10)/4608;
		
		Q = (char)(wPart/100);
		*ss = Q+48;*ss++;
		
		wPart = wPart - Q*100;
		Q = (char)(wPart/10);
		*ss = Q+48;*ss++;
		
		wPart = wPart - Q*10;
		Q = (char)wPart;
		*ss = Q+48;*ss++;
		
		*ss = '.';*ss++;
		
		*ss = (char)(fPart+48);*ss++;
		
		*ss = ' ';*ss++;
		*ss = 'm';*ss++;
		*ss = 's';*ss++;
	}              
	else
	{
		*ss = 'O';*ss++;
		*ss = 'v';*ss++;
		*ss = 'e';*ss++;
		*ss = 'r';*ss++;
		*ss = 'f';*ss++;
		*ss = 'l';*ss++;
		*ss = 'o';*ss++;
		*ss = 'w';*ss++;
	}
	*ss = '\0';
}

void DelayUs(void)
{
	TL1 = 0x90;TH1 = 0xFE;//200 usec at 22.1184MHz
	//TL1 = 0x48;TH1 = 0xFF;//100 usec at 22.1184MHz
	//TL1 = 0xA4;TH1 = 0xFF;//50 usec at 22.1184MHz
	//TL1 = 0xD2;TH1 = 0xFF;//25 usec at 22.1184MHz
	//TL1 = 0xF7;TH1 = 0xFF;//5 usec at 22.1184MHz
	//TL1 = 0xEE;TH1 = 0xFF;//10 usec at 22.1184MHz
	TR1  = 1;
	while(!TF1);
	TR1  = 0;
	TF1  = 0;
}
void Delay10Ms(void)
{
	TL1 = 0x00;TH1 = 0xB8;//10ms at 22.1184MHz
	TR1  = 1;
	while(!TF1);
	TR1  = 0;
	TF1  = 0;
}
void Delay1Ms(void)
{
	TL1 = 0xCD;TH1 = 0xF8;//1ms at 22.1184MHz
	TR1  = 1;
	while(!TF1);
	TR1  = 0;
	TF1  = 0;
}

void DelayMs(void)
{
	TL1 = 0x00;TH1 = 0x04;//35ms at 22.1184MHz
	TR1  = 1;
	while(!TF1);
	TR1  = 0;
	TF1  = 0;
}
// 8bit LCD Interface
void LcdInit()
{
   LcdWriteCmd(0x38);	//Function Set 0x38
   LcdWriteCmd(0x38);	//Function Set
   LcdWriteCmd(0x38);	//Function Set
	LcdWriteCmd(0x06);	//Entry Mode Set 0x06
   LcdWriteCmd(0x0C);	//Display On  Off Control 0x0C
}

void LcdBusy()
{
	BS   = 1;			//Make D7th bit of LCD as i/p
   EN   = 1;         //Make port pin as o/p
   RS   = 0;         //Selected command register
   RW   = 1;         //We are reading
   while(BS)
   {   					//read busy flag again and again till it becomes 0 Enable H->L
   	EN   = 0;
      EN   = 1;
   }
}
void LcdWriteCmd(unsigned char var)
{
	P0 = var;      	//Commands to be Written
   RS   = 0;        	//Selected command register
   RW   = 0;        	//We are writing in instruction register
   EN   = 1;        	//Enable H->L
   EN   = 0;
   LcdBusy();      //Wait for LCD to process the command
}
void LcdWriteChar(unsigned char var)
{
	P0 = var;      	//Data/Character to be Written
   RS   = 1;         //Selected data register
   RW   = 0;         //We are writing
   EN   = 1;         //Enable H->L
   EN   = 0;
   LcdBusy();      //Wait for LCD to process the command
}
void LcdWriteStr(char *var)
{
	while(*var)       //till string ends send characters one by one
   	LcdWriteChar(*var++);
}

void LcdGotoXY(unsigned char row, unsigned char col)
{
	switch (row)
	{
		case 1: LcdWriteCmd(0x80 + col - 1); break;
		case 2: LcdWriteCmd(0xc0 + col - 1); break;
		case 3: LcdWriteCmd(0x94 + col - 1); break;
		case 4: LcdWriteCmd(0xd4 + col - 1); break;
		/*
		case 1: LcdWriteCmd(0x80 + col - 1); break;
		case 2: LcdWriteCmd(0xc0 + col - 1); break;
		case 3: LcdWriteCmd(0x90 + col - 1); break;
		case 4: LcdWriteCmd(0xd0 + col - 1); break;
		*/
		default: break;
	}
}
void LcdClear()
{
 unsigned char h;
 LcdWriteCmd(0x01);
 for(h=0;h<100;h++)
		DelayUs();
}

void SendChar(unsigned char c)
{

	TI=1;
	while (!TI);	TI=0;	SBUF = c;
	while (!TI);	TI=0;
	DelayMs();
}

void SendStr(char *s)
{
	while (*s)
	{
		SendChar(*s);
		s++;
	}
	SendChar('\r');
	SendChar('\n');
}





































