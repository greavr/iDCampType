using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Camp_Type
{
    class CampType
    {
        #region Class Variables & Imports
        string WallpaperValue;
        string StartmenuLoc;
        string IconLoc;
        bool isWin7;
        string ImagesLoc;
        //Wallpaper Imports & Variables
        //--------------------
        private static readonly int SPI_SETDESKWALLPAPER = 20;
        private static readonly int SPIF_UPDATEINIFILE = 1;
        private static readonly int SPIF_SENDWININICHANGE = 2;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        //---------------------
        #endregion

        #region Constructors
        public CampType(string WallPaperLocation, string StartMenuLocation, string ImagesLocation, string IconLocation)
        {
            //Set values
            WallpaperValue = WallPaperLocation;
            StartmenuLoc = StartMenuLocation;
            ImagesLoc = ImagesLocation;
            IconLoc = IconLocation;
            isWin7 = isWindows7();
        }
        #endregion

        #region Private Functions
        private void SetWallpaper()
        {
            //Change the wallpaper value based upon class value

            if (isWin7)
            {
              WallpaperValue = @"C:\Users\Public\Pictures\" + WallpaperValue;
            }
            else
            {
                WallpaperValue = @"C:\Documents and Settings\All Users\Documents\My Pictures\" + WallpaperValue;
            }

            //Actual code to change wallpaper
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, WallpaperValue, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
        
        private void SetStartMenu()
        {
            //Set the startmenu for XP
            string Dst;
            if (isWin7)
                Dst = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs";
            else
                Dst = @"C:\Documents And Settings\All Users\Start Menu\Programs";
          
            try
            {
                copyDirectory(StartmenuLoc, Dst, true);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
                //MessageBox.Show("Problem Copying StartMenu\r\n" + Exc.ToString(), "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyImages()
        {
            //Copy images to required location

            //Dst is targetlocation
            string Dst;
            if (isWin7)
                Dst = @"C:\Users\Public\Pictures";
            else
                Dst = @"C:\Documents and Settings\All Users\Documents\My Pictures\";
            
            //Src is ImagesLoc;
            try
            {
                copyDirectory(ImagesLoc, Dst, true);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
               //MessageBox.Show("Problem Copying Images\r\n" + Exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isWindows7()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                return true;
            else
                return false;
        }

        public static void copyDirectory(string Src, string Dst, bool DeleteExisting)
        {
            //Clean Directory if required
            if (DeleteExisting)
            {
                CleanDirectory(Dst);
            }

            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;

            if (!Directory.Exists(Dst))
            {
                Directory.CreateDirectory(Dst);
            }
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                    copyDirectory(Element, Dst + Path.GetFileName(Element), false);
                // Files in directory
                else
                    File.Copy(Element, Dst + Path.GetFileName(Element));

            }
        }

        public static void CleanDirectory(string Dst)
        {
            //Clean all the files
            string[] files = Directory.GetFiles(Dst);
            foreach (string s in files)
            {
                File.Delete(Path.Combine(Dst, s));
            }

            //List of folders to ignore
            string[] SafeFolderList = {"accessories","startup","administrative tools","tablet pc","games","sample pictures","maintenance"};

            ////Then Remove Folders (except system folders)
            string[] folders = Directory.GetDirectories(Dst);
            bool ShouldDelete = true;

            foreach (string f in folders)
            {
                ShouldDelete = true;
                //Get Foldername
                string ActualFolder =  f.Split('\\').Last();

                //Now check if the folder is safe to delete
                foreach (string DoNotDeletFolder in SafeFolderList)
                {
                    //Check each Safe folder and if its found set to not delete
                    if (ActualFolder.ToLower() == DoNotDeletFolder.ToLower())
                    {
                       ShouldDelete = false;
                    }

                }
                
                //Finally Delete
                if (ShouldDelete)
                    Directory.Delete(f, true);
            }
        }

        private void SetIcon()
        {
            //Dst is the Icon default loaction
            string DST = @"C:\ProgramData\Microsoft\User Account Pictures\user.bmp";

            //Try to copy file now
            try
            {
                //Copy source image to target user.bmp
                File.Copy(IconLoc, DST, true);
            }
            catch
            {
                MessageBox.Show("Unable to copy ICON file","Error");
            }
        }

        #endregion

        #region Public Functions
        public void SetMachine()
        {
            //Set the statmenu then copy images then wallpaper
            SetStartMenu();
            CopyImages();
            SetWallpaper();
            SetIcon();

            //Bam

        }
        #endregion
    }
}
