﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Interface_Form
{
    public static class lastSteeringWheelAngleValue
    {
        public static int lastSteeringWheelAngle = 0;
    }

    public partial class VisualDisplayForm : Form
    {
        public VisualDisplayForm()
        {
            InitializeComponent();
        }

        private void VisualDisplayForm_Load(object sender, EventArgs e)
        {
            General.visualDisplayFormAddress = this;

            visualsUpdateTimer.Enabled = true;
        }

        #region Declaring rectangle objects
        Rectangle frontLeftWheel1, frontLeftWheel2, frontLeftWheel3;
        Rectangle frontRightWheel1, frontRightWheel2, frontRightWheel3;
        Rectangle rearLeftWheel1, rearLeftWheel2, rearLeftWheel3;
        Rectangle rearRightWheel1, rearRightWheel2, rearRightWheel3;

        Rectangle packVoltage, packVoltageEmpty;
        #endregion

        #region Declaring color objects for the rectangles
        Color fl1_color = new Color();
        Color fl2_color = new Color();
        Color fl3_color = new Color();

        Color fr1_color = new Color();
        Color fr2_color = new Color();
        Color fr3_color = new Color();

        Color rl1_color = new Color();
        Color rl2_color = new Color();
        Color rl3_color = new Color();

        Color rr1_color = new Color();
        Color rr2_color = new Color();
        Color rr3_color = new Color();

        Color packVoltage_color = new Color();
        Color packVoltageEmpty_color = new Color();
        #endregion 

        private void VisualDisplayForm_Paint(object sender, PaintEventArgs e)
        {
            #region Create rectangle instances
            frontLeftWheel1 = new Rectangle(20, 60, 15, 80);
            frontLeftWheel2 = new Rectangle(35, 60, 15, 80);
            frontLeftWheel3 = new Rectangle(50, 60, 15, 80);

            frontRightWheel1 = new Rectangle(150, 60, 15, 80);
            frontRightWheel2 = new Rectangle(165, 60, 15, 80);
            frontRightWheel3 = new Rectangle(180, 60, 15, 80);

            rearLeftWheel1 = new Rectangle(20, 340, 15, 80);
            rearLeftWheel2 = new Rectangle(35, 340, 15, 80);
            rearLeftWheel3 = new Rectangle(50, 340, 15, 80);

            rearRightWheel1 = new Rectangle(150, 340, 15, 80);
            rearRightWheel2 = new Rectangle(165, 340, 15, 80);
            rearRightWheel3 = new Rectangle(180, 340, 15, 80);

            packVoltage = new Rectangle(300, 60, 50, 20);
            packVoltageEmpty = new Rectangle(350, 60, 10, 20);
            #endregion

            #region Rotates Front Wheels Based on Steering Angle
            if (lastSteeringWheelAngleValue.lastSteeringWheelAngle != (float)General.steeringAngle)
            {
                steeringWheel.Image = RotateImage(steeringWheel.Image, (float)General.steeringAngle);
                lastSteeringWheelAngleValue.lastSteeringWheelAngle = General.steeringAngle
            }
            //frontLeftWheel1 = rotateRectangle(frontLeftWheel1);
            //frontLeftWheel2 = rotateRectangle(frontLeftWheel2);
            //frontLeftWheel3 = rotateRectangle(frontLeftWheel3);
            //rotateRectangle(ref frontRightWheel1);
            //rotateRectangle(ref frontRightWheel2);
            //rotateRectangle(ref frontRightWheel3);
            #endregion


            #region Create solid brush instances to color the rectangles
            SolidBrush fl1 = new SolidBrush(fl1_color);
            SolidBrush fl2 = new SolidBrush(fl2_color);
            SolidBrush fl3 = new SolidBrush(fl3_color);

            SolidBrush fr1 = new SolidBrush(fr1_color);
            SolidBrush fr2 = new SolidBrush(fr2_color);
            SolidBrush fr3 = new SolidBrush(fr3_color);

            SolidBrush rl1 = new SolidBrush(rl1_color);
            SolidBrush rl2 = new SolidBrush(rl2_color);
            SolidBrush rl3 = new SolidBrush(rl3_color);

            SolidBrush rr1 = new SolidBrush(rr1_color);
            SolidBrush rr2 = new SolidBrush(rr2_color);
            SolidBrush rr3 = new SolidBrush(rr3_color);

            SolidBrush voltageBrush = new SolidBrush(packVoltage_color);
            SolidBrush voltageEmptyBrush = new SolidBrush(packVoltageEmpty_color);
            #endregion

            #region Initially fill the color of the rectangles at visuals form openning
            e.Graphics.FillRectangle(fl1, frontLeftWheel1);
            e.Graphics.FillRectangle(fl2, frontLeftWheel2);
            e.Graphics.FillRectangle(fl3, frontLeftWheel3);

            e.Graphics.FillRectangle(fr1, frontRightWheel1);
            e.Graphics.FillRectangle(fr2, frontRightWheel2);
            e.Graphics.FillRectangle(fr3, frontRightWheel3);

            e.Graphics.FillRectangle(rl1, rearLeftWheel1);
            e.Graphics.FillRectangle(rl2, rearLeftWheel2);
            e.Graphics.FillRectangle(rl3, rearLeftWheel3);

            e.Graphics.FillRectangle(rr1, rearRightWheel1);
            e.Graphics.FillRectangle(rr2, rearRightWheel2);
            e.Graphics.FillRectangle(rr3, rearRightWheel3);

            e.Graphics.FillRectangle(voltageBrush, packVoltage);
            e.Graphics.FillRectangle(voltageEmptyBrush, packVoltageEmpty);
            #endregion
        }

        private void visualsUpdateTimer_Tick(object sender, EventArgs e)
        {
            
            //General.TTBL1 is divided by 200 in order to get it into a percentage approximately
            double x_fl1 = (((double)(General.TTFL1)) / 200.0);
            double x_fl2 = (((double)(General.TTFL2)) / 200.0);
            double x_fl3 = (((double)(General.TTFL3)) / 200.0);

            double x_fr1 = (((double)(General.TTFR1)) / 200.0);
            double x_fr2 = (((double)(General.TTFR2)) / 200.0);
            double x_fr3 = (((double)(General.TTFR3)) / 200.0);

            double x_rl1 = (((double)(General.TTBL1)) / 200.0);
            double x_rl2 = (((double)(General.TTBL2)) / 200.0);
            double x_rl3 = (((double)(General.TTBL3)) / 200.0);

            double x_rr1 = (((double)(General.TTBR1)) / 200.0);
            double x_rr2 = (((double)(General.TTBR2)) / 200.0);
            double x_rr3 = (((double)(General.TTBR3)) / 200.0);

            double x_packVoltage = ((General.packVoltage)*(1/255.0)*(60.0));
            double x_packVoltageEmpty = 60.0 - x_packVoltage;

            packVoltage.Width = (int)x_packVoltage;
            packVoltageEmpty.X = 300 + (int)x_packVoltage;
            packVoltageEmpty.Width = (int)x_packVoltageEmpty;


            //This code will change the intensity of the tire color based on the tire temp
            fl1_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_fl1), (int)((Color.Red.G) * x_fl1), (int)((Color.Red.B) * x_fl1));
            fl2_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_fl2), (int)((Color.Red.G) * x_fl2), (int)((Color.Red.B) * x_fl2));
            fl3_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_fl3), (int)((Color.Red.G) * x_fl3), (int)((Color.Red.B) * x_fl3));

            fr1_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_fr1), (int)((Color.Red.G) * x_fr1), (int)((Color.Red.B) * x_fr1));
            fr2_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_fr2), (int)((Color.Red.G) * x_fr2), (int)((Color.Red.B) * x_fr2));
            fr3_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_fr3), (int)((Color.Red.G) * x_fr3), (int)((Color.Red.B) * x_fr3));

            rl1_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_rl1), (int)((Color.Red.G) * x_rl1), (int)((Color.Red.B) * x_rl1));
            rl2_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_rl2), (int)((Color.Red.G) * x_rl2), (int)((Color.Red.B) * x_rl2));
            rl3_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_rl3), (int)((Color.Red.G) * x_rl3), (int)((Color.Red.B) * x_rl3));

            rr1_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_rr1), (int)((Color.Red.G) * x_rr1), (int)((Color.Red.B) * x_rr1));
            rr2_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_rr2), (int)((Color.Red.G) * x_rr2), (int)((Color.Red.B) * x_rr2));
            rr3_color = Color.FromArgb(Color.Red.A, (int)((Color.Red.R) * x_rr3), (int)((Color.Red.G) * x_rr3), (int)((Color.Red.B) * x_rr3));

            packVoltage_color = Color.Green;
            packVoltageEmpty_color = Color.Black;

            this.Invalidate();
        }


        public static Bitmap RotateImage(Image b, float angle) // Source: https://stackoverflow.com/questions/27431345/rotating-image-around-center-c-sharp?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        {
            //Create a new empty bitmap to hold rotated image.
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //Make a graphics object from the empty bitmap.
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image.
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //Rotate.        
            g.RotateTransform(angle);
            //Move image back.
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //Draw passed in image onto graphics object.
            //Found ERROR 1: Many people do g.DwarImage(b,0,0); The problem is that you re giving just the position
            //Found ERROR 2: Many people do g.DrawImage(b, new Point(0,0)); The size still not present hehe :3

            g.DrawImage(b, 0, 0, b.Width, b.Height);  //My Final Solution :3
            return returnBitmap;
        }
    }
}
