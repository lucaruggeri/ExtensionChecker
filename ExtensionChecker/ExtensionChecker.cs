using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtensionChecker
{
    public static class ExtensionChecker
    {

        //  controlla se l'ESTENSIONE ricavata dal nome del file corrisponde al FILE TYPE ricavato dal suo header
        public static bool CheckFileExtension(string filePath)
        {
            bool estensioniCorrispondono = false;

            // ricava l'estensione dichiarata
            string declaredExtension = GetDeclaredExtension(filePath);
            declaredExtension = declaredExtension.Replace(".", " ").Trim().ToUpper();

            // ricava l'estensione vera
            string realExtension = GetRealExtension(filePath);
            realExtension = realExtension.Replace(".", " ").Trim().ToUpper();

            // confronta le estensioni e ritorna un responso 
            if (declaredExtension == realExtension)
            {
                estensioniCorrispondono = true;
            }
            else
            {
                estensioniCorrispondono = false;
            }

            return estensioniCorrispondono;
        }

        // legge l'header di un file e lo trasforma in valori esadecimali
        private static List<string> FileHeaderToHexadecimal(string path)
        {
            List<string> twoDigitsHexadecimal = new List<string>(20);

            try
            {
                // STREAM
                FileStream fs = File.Open(path, FileMode.Open);

                // ARRAY DI BYTE
                Byte[] b = new byte[20];

                // lettura dei primi 20 BYTE
                fs.Read(b, 0, 20);

                // trasformazione 
                // da ARRAY DI BYTE
                // a ARRAY DI STRINGHE (valori esadecimali)
                int i = 0;
                foreach (Byte myByte in b)
                {
                    //twoDigitsHexadecimal[i] = myByte.ToString("X2");
                    twoDigitsHexadecimal.Add(myByte.ToString("X2"));
                    i = i + 1;
                }

                fs.Close();
            }
            catch
            { 
            }

            return twoDigitsHexadecimal;
        }

        // restituisce l'estensione dichiarata del file 
        // (ricavata semplicemente dal nome)
        private static string GetDeclaredExtension(string path)
        {
            string declaredExtension = null;

            string fileName = Path.GetFileName(path);
            declaredExtension = Path.GetExtension(fileName);

            return declaredExtension;
        }

        // restituisce l'estensione vera del file 
        // (ricavata analizzando l'header)
        private static string GetRealExtension(string filePath)
        {

            // ricava i valori esadecimali dell'header del file
            List<string> twoDigitsHexadecimal = FileHeaderToHexadecimal(filePath);

            // cerca i valori esadecimali ottenuti in un archivio di FILE TYPE noti
            string realExtension = SearchForKnownFileType(twoDigitsHexadecimal);

            return realExtension;
        }

        // cerca i valori esadecimali ottenuti in un archivio di FILE TYPE noti
        private static string SearchForKnownFileType(List<string> twoDigitsHexadecimal)
        {
            string extensionFound = "(UNKNOWN)";

            // archivio FILE TYPE
            List<FileType> archivioFileType = new List<FileType>();
            archivioFileType.Add(new FileType("PDF", new List<string> { "25", "50", "44", "46" }));
            archivioFileType.Add(new FileType("DOC", new List<string> { "D0", "CF", "11", "E0", "A1", "B1", "1A", "E1" }));
            archivioFileType.Add(new FileType("DOCX", new List<string> { "50", "4B", "03", "04" }));
            archivioFileType.Add(new FileType("DOCX", new List<string> { "50", "4B", "05", "06" }));
            archivioFileType.Add(new FileType("DOCX", new List<string> { "50", "4B", "07", "08" }));
            archivioFileType.Add(new FileType("RTF", new List<string> { "7B", "5C", "72", "74", "66", "31" }));
            
            // confronto dell'HEADER del FILE con quelli in archivio
            foreach(FileType f in archivioFileType)
            {
                if (CompareHeaders(twoDigitsHexadecimal, f.Header))
                {
                    extensionFound = f.Name;
                }
            }

            return extensionFound;
        }

        private static bool CompareHeaders(List<string> twoDigitsHexadecimal, List<string> fileHeader)
        {
            bool result = true;

            // confronta i valori di una LIST rispetto a un'altra LIST
            // nell'ordine esatto
            for (int i = 0; i < fileHeader.Count(); i++)
            {
                if (fileHeader[i] != twoDigitsHexadecimal[i])
                {
                    result = false;
                }
            }
            
            return result;
        }

    }

    public class FileType
    {
        public string Name;
        public List<string> Header;

        public FileType(string fileTypeName, List<string> fileTypeHeader)
        {
            Name = fileTypeName;
            Header = fileTypeHeader;
        }

    }

}



