using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/** WaffleImageSpliter
* This program will allow a user to take an image and split
* it up into specified sized tiles (separate images). These
* tiles can then be reassembled in a level editor to recreate
* the image.
*
* This was uploaded to Katianie.com, Feel free to use this
* code and share it with others, Just give me credit ^_^.
*
* Eddie O'Hagan
* Copyright © 2013 Katianie.com
*/

namespace WaffleImageSpliter
{
    public partial class Form1 : Form
    {
        private Image myChopImage;
        private Image myOriginalImage;
        private Color myEmptySpaceColor;
        private string myCurrentStatus;
        private string myFileFilter;
        private string myImagePath;
        private string myTilePrefexName;
        private int myTileWidth;
        private int myTileHeight;

        public Form1()
        {
            myEmptySpaceColor = Color.White;
            myImagePath = null;
            myTilePrefexName = "Tile";
            myCurrentStatus = "Waiting For User...";
            myFileFilter = "JPEG Images (*.jpg)|*.jpg|" +
                           "PNG Images (*.png)|*.png|" +
                           "BMP Images (*.bmp)|*.bmp";

            myTileWidth = -1;
            myTileHeight = -1;

            InitializeComponent();

            lblStatus.Text = myCurrentStatus;
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();

            colorDlg.AnyColor = true; //ColorDialog displays all available colors in the set of basic colors.
            colorDlg.SolidColorOnly = false; //ColorDialog DOES NOT restrict user to selecting solid colors only.

            colorDlg.ShowDialog();

            myEmptySpaceColor = colorDlg.Color;

        }

        private void btnBrowseForImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult userClickedOK;

            // Set filter options and filter index.
            openFileDialog.Filter = myFileFilter;
            openFileDialog.FilterIndex = 1;

            //We can only manipulate one image at a time
            openFileDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            userClickedOK = openFileDialog.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                // Open the selected file to read.
                myImagePath = openFileDialog.FileName;

                if (myImagePath != null)
                {
                    myOriginalImage = Image.FromFile(myImagePath);

                    picboxImagePreview.Image = myOriginalImage;
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            int check = 0;

            check = GenerateChopImage();

            if (check >= 0)
            {
                DrawGridLines();
            }

            //Update the current status.
            myCurrentStatus = "Waiting For User...";
            lblStatus.Text = myCurrentStatus;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog;
            DialogResult userClickedOK;
            Image tempTile;
            Rectangle rect;
            string saveDir = "";
            int currRow = 1;
            int currCol = 1;
            int currX = 0; //Used for splitting. Initialized to origin x.
            int currY = 0; //Used for splitting. Initialized to origin y.
            int check = 0;

            myTilePrefexName = txtPrefexName.Text;

            //If the newly created image is not created
            //then create it.
            if (myChopImage == null)
            {
                check = GenerateChopImage();
            }

            if (check >= 0)
            {
                //Ask user where they want to save the tiles.
                folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select a folder to save the tiles.";

                //Update the current status.
                myCurrentStatus = "User is selecting a Directory.";
                lblStatus.Text = myCurrentStatus;

                //Call the ShowDialog method to show the dialog box.
                userClickedOK = folderBrowserDialog.ShowDialog();

                //Process input if the user clicked OK.
                if (userClickedOK == DialogResult.OK)
                {
                    //Update the current status.
                    myCurrentStatus = "Processing...";
                    lblStatus.Text = myCurrentStatus;

                    saveDir = folderBrowserDialog.SelectedPath;

                    while (currY < myChopImage.Height)
                    {
                        while (currX < myChopImage.Width)
                        {
                            //Create a single tile
                            rect = new Rectangle(currX, currY, myTileWidth, myTileHeight);
                            tempTile = ChopImage((Bitmap) myChopImage, rect);

                            tempTile.Save(saveDir + "\\" + myTilePrefexName + "_" + currRow + "_" + currCol + ".bmp");

                            currCol++;
                            currX += myTileWidth;
                        }

                        //Reset the current row to start over on the next col.
                        currCol = 1;
                        currX = 0;

                        currRow++;
                        currY += myTileHeight;
                    }

                    DrawGridLines();

                    //Update the current status.
                    myCurrentStatus = "Done!";
                    lblStatus.Text = myCurrentStatus;
                }
            }
        }

        //Take a small section defined by a rectangle of a larger
        //image and return that smaller section image.
        private Bitmap ChopImage(Bitmap bmp, Rectangle chopArea)
        {
            Bitmap bmpChop;

            //Update the current status.
            myCurrentStatus = "Generating a single tile.";
            lblStatus.Text = myCurrentStatus;

            bmpChop = bmp.Clone(chopArea, myChopImage.PixelFormat);

            return bmpChop;
        }

        //Draws the grid lines for where the image will be chopped.
        //returns 0 on success -1 on failure
        public int DrawGridLines()
        {
            Image gridImage = myChopImage;
            Graphics g = Graphics.FromImage(gridImage);
            Pen aPen = new Pen(Color.Black, 1);
            int currX = 0; //Used for drawing grid lines. Initialized to origin x.
            int currY = 0; //Used for drawing grid lines. Initialized to origin y.

            //Update the current status.
            myCurrentStatus = "Drawing grid lines.";
            lblStatus.Text = myCurrentStatus;

            //Draw the grid lines on the image
            while (currX < gridImage.Width)
            {
                currX += myTileWidth;
                g.DrawLine(aPen, currX, 0.0f, currX, gridImage.Height);
            }

            //Draw the grid lines on the image
            while (currY < gridImage.Height)
            {
                currY += myTileHeight;
                g.DrawLine(aPen, 0.0f, currY, gridImage.Width, currY);
            }

            picboxImagePreview.Image = gridImage;

            return 0;
        }

        //This will take the image, create a new one using the empty color.
        //returns 0 on success -1 on failure
        public int GenerateChopImage()
        {
            Graphics g;
            Rectangle rect;
            LinearGradientBrush lBrush;
            TextureBrush textureBrush;
            string tileWidthString = txtTileWidth.Text;
            string tileHeightString = txtTileHeight.Text;
            int chopImageWidth = 0;
            int chopImageHeight = 0;
            double widthResult = 0.0;
            double heightResult = 0.0;

            //Update the current status.
            myCurrentStatus = "Generating larger image.";
            lblStatus.Text = myCurrentStatus;

            if (tileWidthString == null || tileHeightString == null || tileWidthString == "" || tileHeightString == "")
            {
                //Error, user must fill out the width and height
                MessageBox.Show("Error: Please enter values for tile width and tile height.");
                return -1;
            }

            if (myOriginalImage == null)
            {
                //Error, user must provide an image
                MessageBox.Show("Error: Please provide an image to work with.");
                return -2;
            }

            tileWidthString = tileWidthString.Trim();
            tileHeightString = tileHeightString.Trim();

            myTileWidth = int.Parse(tileWidthString);
            myTileHeight = int.Parse(tileHeightString);

            //Divide to see if there is a remainder meaning we have to
            //make the our chopping image bigger so we have even tiles
            widthResult = (double)myOriginalImage.Width / (double)myTileWidth;
            widthResult = Math.Ceiling(widthResult);

            heightResult = (double)myOriginalImage.Height / (double)myTileHeight;
            heightResult = Math.Ceiling(heightResult);

            //Now calculate the new width and height
            chopImageWidth = (int)widthResult * myTileWidth;
            chopImageHeight = (int)heightResult * myTileHeight;

            //Now we need to create a new image but set the color
            //of this new image to the one the user selected so
            //when we copy the original, the color will be in the back.
            myChopImage = new Bitmap(chopImageWidth, chopImageHeight);

            //Take the empty space color and fill it as the background color of
            //the new image that was made.
            g = Graphics.FromImage(myChopImage);
            rect = new Rectangle(0, 0, chopImageWidth, chopImageHeight);
            lBrush = new LinearGradientBrush(rect, myEmptySpaceColor, myEmptySpaceColor, LinearGradientMode.Horizontal);

            g.FillRectangle(lBrush, rect);

            //Copy over the original image and save it on top
            //of the new bigger image with the empty color as 
            //the background.
            textureBrush = new TextureBrush(myOriginalImage);
            textureBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
            g.FillRectangle(textureBrush, new Rectangle(0, 0, myOriginalImage.Width, myOriginalImage.Height));

            //Update the display to show the chop image
            picboxImagePreview.Image = myChopImage;

            //The chop image has been created and we are done here.
            g.Dispose();

            return 0;
        }

    }
}
