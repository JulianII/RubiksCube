using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RubiksCube.Model
{
    class SaveManager
    {
        private string savePath;
        string fileName = "save";
        string path;

        public SaveManager() 
        {
            savePath = System.IO.Directory.GetCurrentDirectory() + "\\Saves\\";
            path = savePath + fileName;
        }    

        public void Save(Cube c) 
        {
            string fileName = "save";

            string path = savePath + fileName;

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string s = "";
            for (int i = 0; i < 9; ++i) s += c.FrontFace.Plates[i] + ";";
            for (int i = 0; i < 9; ++i) s += c.BackFace.Plates[i] + ";";

            for (int i = 0; i < 9; ++i) s += c.LeftFace.Plates[i] + ";";
            for (int i = 0; i < 9; ++i) s += c.RightFace.Plates[i] + ";";

            for (int i = 0; i < 9; ++i) s += c.TopFace.Plates[i] + ";";
            for (int i = 0; i < 9; ++i) s += c.BottomFace.Plates[i] + ";";

            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(s);
                
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }

        public Cube Load() 
        {
            Cube c = new Cube();

            try
            {
                string fileContent = File.ReadAllText(path);
                string[] output = fileContent.Split(";");

                for (int i = 0; i < 9; ++i) c.FrontFace.SetPlateColor(i, new SolidColorBrush((Color)ColorConverter.ConvertFromString(output[i + 9 * 0])));
                for (int i = 0; i < 9; ++i) c.BackFace.SetPlateColor(i, new SolidColorBrush((Color)ColorConverter.ConvertFromString(output[i + 9 * 1])));

                for (int i = 0; i < 9; ++i) c.LeftFace.SetPlateColor(i, new SolidColorBrush((Color)ColorConverter.ConvertFromString(output[i + 9 * 2])));
                for (int i = 0; i < 9; ++i) c.RightFace.SetPlateColor(i, new SolidColorBrush((Color)ColorConverter.ConvertFromString(output[i + 9 * 3])));

                for (int i = 0; i < 9; ++i) c.TopFace.SetPlateColor(i, new SolidColorBrush((Color)ColorConverter.ConvertFromString(output[i + 9 * 4])));
                for (int i = 0; i < 9; ++i) c.BottomFace.SetPlateColor(i, new SolidColorBrush((Color)ColorConverter.ConvertFromString(output[i + 9 * 5])));
            } catch { 
                c = null;
            }

            return c;
        }
    }
}
