/*
 * UTAC - USB TEMPer Advanced Control
 * -----------------------------------------------------------------------
 * Homepage: http://utac.n4rf.net
 * Bugtracker: http://bugtracker.n4rf.net
 * SourceForge Project Page: http://sourceforge.net/projects/utac/
 * Mail Contact: info@n4rf.net
 * -----------------------------------------------------------------------
 * 
 * UTAC is a GUI for the TEMPer and TEMPerHum USB Thermometer
 * Copyright (C) Bjoern Boettcher 2008
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * -----------------------------------------------------------------------
 * --------------------------------------------------* File Information *-
 * -----------------------------------------------------------------------
 * FileName: 	LED.cs
 * Namespace: 	utac.Components.LED
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * This class creates an LED image based upon a numeric string
 * Uses a flexible byte array versus hard coding the character image creation
 * Based on the LEDCounter from John ODonnell
 * 
 * Orignal from Scott Penner - March 28, 2002 - sdpenner@yahoo.com
 * 
 * Modified by Bjoern -bof- Boettcher for Dots,Degrees and Percentage
 * for UTAC.
 */

using System;
using System.Drawing;

namespace utac.Components.LED
{
public class LED
{
private const int defaultCharacterSize = 31 ;
private byte[,] locationOfLEDs ;
private int characterSize ;
private readonly Color outerColor;
private readonly Color innerColor;
/// <summary>
/// Contructs green LED with default size
/// </summary>
public LED()
{
// Default constructor
characterSize = defaultCharacterSize ;
innerColor = Color.Green;
outerColor = Color.SeaGreen;
FillByteArray();
}
/// <summary>
/// Contructs LED with default size and user specified color
/// </summary>
public LED(Color LEDinnerColor, Color LEDouterColor)
{
// Color constructor - sets the inner and outer LED colors
characterSize = defaultCharacterSize ;
innerColor = LEDinnerColor;
outerColor = LEDouterColor;
FillByteArray();
}
/// <summary>
/// Build an image from a numeric string
/// </summary>
/// <param name="number"></param>
/// <returns></returns>
public Image CreateLEDDisplay(string number)
{
int StartPixel = 0;
int StringLength = number.Length;
// Create a rectangular bitmap with string length * character size width and character size height
Image CompleteBitmap = new Bitmap(StringLength * characterSize, characterSize);
// Get graphics object from bitmap
Graphics BitmapGraphicsObject = Graphics.FromImage(CompleteBitmap);
// Loop through the string to build up the bitmap
for(int k=0; k < StringLength ; k++)
{
Image BitmapOfOneCharacter = new Bitmap(characterSize, characterSize);
characterSize = defaultCharacterSize ;
BitmapOfOneCharacter=CreateLEDDigit(makeint(number.Substring(k,1)));
BitmapGraphicsObject.DrawImage(BitmapOfOneCharacter, StartPixel, 0);
StartPixel += characterSize;
}
BitmapGraphicsObject.Save();
return CompleteBitmap;
}
private void FillByteArray()
{
// Byte array holds the locations of the leds for a particular character
// This can be more easily extended to alphanumeric
// --- 0
// | | 1 2
// --- 3
// | | 4 5
// --- 6
// 0 1 2 3 4 5 6
locationOfLEDs = new byte[15,7] { 
{1, 1, 1, 0, 1, 1, 1} , // 0
{0, 0, 1, 0, 0, 1, 0} , // 1
{1, 0, 1, 1, 1, 0, 1} , // 2
{1, 0, 1, 1, 0, 1, 1} , // 3
{0, 1, 1, 1, 0, 1, 0} , // 4
{1, 1, 0, 1, 0, 1, 1} , // 5
{1, 1, 0, 1, 1, 1, 1} , // 6
{1, 0, 1, 0, 0, 1, 0} , // 7
{1, 1, 1, 1, 1, 1, 1} , // 8
{1, 1, 1, 1, 0, 1, 1} , // 9
{1, 1, 0, 0, 1, 0, 1} , // C (10)
{1, 1, 0, 1, 1, 0, 0} , // F (11)
{0, 0, 0, 1, 0, 0, 0} , // - (12)
{0, 0, 0, 0, 0, 0, 0} , // . (13)
{0, 0, 0, 0, 0, 0, 0} }; // ° (14)
}


private static int makeint(string val)
{
	if(val == "1" || val == "2" || val == "3" || val == "4" || val == "5" ||
	   val == "6" || val == "7" ||  val == "8" || val == "9" || val == "0"){
		return Convert.ToInt32(val);
	} else {
	   string myval = val.ToUpper();
	   switch (myval)
	   {
	   	case "C":
	   		return 10;
	   	case "F":
	   		return 11; 
	    case "-":
	   		return 12;
	   	case ".":
	   		return 13;
	   	case ",":
	   		return 13;
	   	case "°":
	   		return 14;
	   	case "%":
	   		return 15;
	   	default:
	   		return -1;
	   }
	}
	   

}


private Image CreateLEDDigit(int val)
{
Image CharacterImage = new Bitmap(characterSize,characterSize);
Graphics g=Graphics.FromImage(CharacterImage);
Pen InnerPen = new Pen(innerColor) ;
Pen OuterPen = new Pen(outerColor) ;
if (val < 0 || val > 12){	
	
	switch (val)
	{
		//Dot
		case -1:
			characterSize = 8;
			break;
		case 13:
			g.DrawLine(OuterPen,5,28,7,28);
			g.DrawLine(InnerPen,4,29,8,29);
			g.DrawLine(OuterPen,5,30,7,30);
			characterSize = 10;
			g.Save();
			break;
		case 14:
			g.DrawLine(OuterPen,5,2,6,2);
			g.DrawLine(InnerPen,4,3,7,3);
			g.DrawLine(OuterPen,5,4,6,4);
			characterSize = 10;
			g.Save();
			break;
		case 15:
			g.DrawLine(OuterPen,5,2,6,2);
			g.DrawLine(InnerPen,4,3,7,3);
			g.DrawLine(OuterPen,5,4,6,4);
			g.DrawLine(OuterPen,25,28,26,28);
			g.DrawLine(InnerPen,24,29,27,29);
			g.DrawLine(OuterPen,25,30,26,30);
			g.DrawLine(OuterPen,28,3,3,28);
			g.DrawLine(InnerPen,28,4,4,28);
			g.DrawLine(OuterPen,28,5,5,28);
			characterSize = 10;
			g.Save();
			break;
	}
	

	return CharacterImage;	
}

// Draw a line for each LED
if (locationOfLEDs[val,0] == 1)
{
//TOP
g.DrawLine(OuterPen,5,2,27,2);
g.DrawLine(InnerPen,4,3,28,3);
g.DrawLine(OuterPen,5,4,27,4);
}
if (locationOfLEDs[val,1] == 1)
{
//TOP LEFT
g.DrawLine(OuterPen,2,5,2,14);
g.DrawLine(InnerPen,3,4,3,15);
g.DrawLine(OuterPen,4,5,4,14);
}
if (locationOfLEDs[val,2] == 1)
{
//TOP RIGHT
g.DrawLine(OuterPen,28,5,28,14);
g.DrawLine(InnerPen,29,4,29,15);
g.DrawLine(OuterPen,30,5,30,14);
}
if (locationOfLEDs[val,3] == 1)
{
//MIDDLE
g.DrawLine(OuterPen,5,15,27,15);
g.DrawLine(InnerPen,4,16,28,16);
g.DrawLine(OuterPen,5,17,27,17);
}
if (locationOfLEDs[val,4] == 1)
{
//BOTTOM LEFT
g.DrawLine(OuterPen,2,18,2,27);
g.DrawLine(InnerPen,3,17,3,28);
g.DrawLine(OuterPen,4,18,4,27);
}
if (locationOfLEDs[val,5] == 1)
{
//BOTTOM RIGHT
g.DrawLine(OuterPen,30,18,30,27);
g.DrawLine(InnerPen,29,17,29,28);
g.DrawLine(OuterPen,28,18,28,27);
}
if (locationOfLEDs[val,6] == 1)
{
//BOTTOM
g.DrawLine(OuterPen,5,28,27,28);
g.DrawLine(InnerPen,4,29,28,29);
g.DrawLine(OuterPen,5,30,27,30);
}

g.Save();
return CharacterImage;
}
}
}
