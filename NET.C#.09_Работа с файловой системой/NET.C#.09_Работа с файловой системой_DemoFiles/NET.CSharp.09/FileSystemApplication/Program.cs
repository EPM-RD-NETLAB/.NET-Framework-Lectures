using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FileSystemApplication
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //------------------------------------------
            // Reading and Writing from Files.
            //------------------------------------------

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "MyTextFile.txt";
            string fileContents;

            #region Writing examples

            string[] fileLines = { "Line 1", "Line 2", "Line 3" };
            File.AppendAllLines(filePath, fileLines);

            fileContents = "I am writing this text to a file called MyTextFile.txt";
            File.AppendAllText(filePath, fileContents);

            byte[] fileBytes = { 12, 134, 12, 8, 32 };
            File.WriteAllBytes(filePath, fileBytes);

            File.WriteAllLines(filePath, fileLines);

            File.WriteAllText(filePath, fileContents);

            #endregion

            #region Reading examples

            byte[] data = File.ReadAllBytes(filePath);

            string[] lines = File.ReadAllLines(filePath);

            string data2 = File.ReadAllText(filePath);


            #endregion

            //------------------------------------------
            // Manipulating Directories.
            //------------------------------------------

            string dirPath = AppDomain.CurrentDomain.BaseDirectory + @"\Temp";
            #region Directory class members

            Directory.CreateDirectory(dirPath);
            //Directory.Delete(dirPath); // You may want to change the path before demonstrating Delete()
            string[] dirs = Directory.GetDirectories(dirPath);
            string[] files = Directory.GetFiles(dirPath);

            #endregion

            #region DirectoryInfo class members

            DirectoryInfo dir = new DirectoryInfo(dirPath);
            bool exists = dir.Exists;
            DirectoryInfo[] dirs2 = dir.GetDirectories();
            FileInfo[] files2 = dir.GetFiles();
            string fullName = dir.FullName;


            #endregion

            #region Enumerating directory contents

            dirPath = @"C:\Temp";

            // Get all sub directories in the Documents directory.
            string[] subDirs = Directory.GetDirectories(dirPath);

            foreach (string dir3 in subDirs)
            {
                // Display the directory name.
                Console.WriteLine("{0} contains the following files:", dir3);

                // Get all the files in each directory.
                files = Directory.GetFiles(dir3);

                foreach (string file in files)
                {
                    // Display the file name.
                    Console.WriteLine(file);
                }
            }

            #endregion

            //------------------------------------------
            // Using the Common File System Dialog Boxes
            //------------------------------------------

            #region Open and Save dialog examples

            OpenFileDialog openDlg = new OpenFileDialog();

            SaveFileDialog saveDlg = new SaveFileDialog();


            openDlg.Title = "Browse for a file to open";
            openDlg.Multiselect = false;
            openDlg.InitialDirectory = @"C:\Users\anzhelika\Desktop\cd clr via c# - 2010";
            openDlg.Filter = "Word (*.doc) |*.doc;";

            saveDlg.Title = "Browse for a save location";
            saveDlg.DefaultExt = "doc";
            saveDlg.AddExtension = true;
            saveDlg.InitialDirectory = @"C:\Users\anzhelika\Desktop\cd clr via c# - 2010";
            saveDlg.OverwritePrompt = true;

            openDlg.ShowDialog();

            saveDlg.ShowDialog();

            string selectedFileName = openDlg.FileName;

            string selectedFileName2 = saveDlg.FileName;


            #endregion

            ////------------------------------------------
            //// Reading and Writing Binary data
            ////------------------------------------------

            #region Writing

            string destinationFilePath = AppDomain.CurrentDomain.BaseDirectory + "BinaryDataFile.bin";

            // Collection of bytes.
            byte[] dataCollection = { 1, 4, 6, 7, 12, 33, 26, 98, 82, 101 };

            // Create a FileStream object so that you can interact with the file 
            // system.
            FileStream destFile = new FileStream(destinationFilePath, // Pass in the destination path.
                                                 FileMode.Create,     // Always create new file.
                                                 FileAccess.Write);   // Only perform writing.

            // Create a BinaryWriter object passing in the FileStream object.
            BinaryWriter writer = new BinaryWriter(destFile);

            // Write each byte to stream.
            foreach (var dataItem in dataCollection)
            {
                writer.Write(dataItem);
            }

            // Close both streams to flush the data to the file.
            writer.Close();
            destFile.Close();

            #endregion

            #region Reading

            // Source file path.
            string sourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "BinaryDataFile.bin";

            // Create a FileStream object so that you can interact with the file system.
            FileStream sourceFile = new FileStream(
                sourceFilePath,  // Pass in the source file path.
                FileMode.Open,   // Open an existing file.
                FileAccess.Read);// Read an existing file.

            // Create a BinaryWriter object passing in the FileStream object.
            BinaryReader reader = new BinaryReader(sourceFile);

            // Store the current position of the stream.
            int position = 0;
            // Store the length of the stream.
            int length = (int)reader.BaseStream.Length;

            // Create an array to store each byte from the file.
            byte[] dataCollection2 = new byte[length];
            int returnedByte;
            while ((returnedByte = reader.Read()) != -1)
            {
                // Set the value at the next index.
                dataCollection2[position] = (byte)returnedByte;

                // Advance our position variable.
                position += sizeof(byte);
            }

            // Close the streams to release any file handles.
            reader.Close();
            sourceFile.Close();


            #endregion

            //------------------------------------------
            // Reading and Writing BText
            //------------------------------------------

            #region Writing

            destinationFilePath = AppDomain.CurrentDomain.BaseDirectory + "TextDataFile.txt";

            string data4 = "Hello, this will be written in plain text";

            // Create a FileStream object so that you can interact with the file system.
            FileStream destFile1 = new FileStream(destinationFilePath, // Pass in the destination path.
                                                  FileMode.Create,     // Always create new file.
                                                  FileAccess.Write);   // Only perform writing.

            // Create a new StreamWriter object.
            StreamWriter writer1 = new StreamWriter(destFile1);

            // Write the string to the file.
            writer1.WriteLine(data4);

            // Always close the underlying streams to flush the data to the file 
            // and release any file handles.
            writer1.Close();
            destFile1.Close();


            #endregion

            #region Reading

            sourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "TextDataFile.txt";

            // Create a FileStream object so that you can interact with the file system.
            FileStream sourceFile3 = new FileStream(sourceFilePath,  // Pass in the source file path.
                                                    FileMode.Open,   // Open an existing file.
                                                    FileAccess.Read);// Read an existing file.

            StreamReader reader3 = new StreamReader(sourceFile3);
            StringBuilder fileContents3 = new StringBuilder();

            // Check to see if the end of the file
            // has been reached.
            while (reader3.Peek() != -1)
            {
                // Read the next character.
                fileContents3.Append((char)reader3.Read());
            }

            // Store the file contents in a new string variable.
            string data5 = fileContents3.ToString();

            // Always close the underlying streams release any file handles.
            reader.Close();
            sourceFile3.Close();


            #endregion

            //------------------------------------------
            // Reading and Writing Primitive Data Types
            //------------------------------------------
            #region Writing
            // Create a FileStream object so that you can interact with the file system.
            sourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "PrimitiveDataTypeFile.txt";
            FileStream destFile2 = new FileStream(sourceFilePath, // Pass in the destination path.
                                                  FileMode.Create,     // Always create new file.
                                                  FileAccess.Write);   // Only perform writing.
            // Create a BinaryWriter object passing in the FileStream object.
            BinaryWriter writer2 = new BinaryWriter(destFile2);
            bool boolValue = true;
            writer2.Write(boolValue);
            byte byteValue = 1;
            writer2.Write(byteValue);
            byte[] byteArrayValue = { 1, 4, 6, 8 };
            writer2.Write(byteArrayValue);
            char charValue = 'a';
            writer2.Write(charValue);
            char[] charArrayValue = { 'a', 'b', 'c', 'd' };
            writer2.Write(charArrayValue);
            decimal decimalValue = 1.00m;
            writer2.Write(decimalValue);
            double doubleValue = 2.5;
            writer2.Write(doubleValue);
            float floatValue = 4.5f;
            writer2.Write(floatValue);
            int intValue = 999999999;
            writer2.Write(intValue);
            long longValue = 999999999999999999;
            writer2.Write(longValue);
            sbyte sbyteValue = 99;
            writer2.Write(sbyteValue);
            short shortValue = 9999;
            writer2.Write(shortValue);
            string stringValue = "MyString";
            writer2.Write(stringValue);
            uint unintValue = 999999999;
            writer2.Write(unintValue);
            ulong ulongValue = 999999999999999999;
            writer2.Write(ulongValue);
            ushort ushortValue = 9999;
            writer2.Write(ushortValue);
            // Close both streams to flush the data to the file.
            writer2.Close();
            destFile2.Close();

            #endregion

            #region Reading
            // Source file path.
            sourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "PrimitiveDataTypeFile.txt";
            // Create a FileStream object so that you can interact with the file
            // system.
            //FileStream sourceFile2 = new FileStream(
            //sourceFilePath,  // Pass in the source file path.
            //FileMode.Open,   // Open an existing file.
            //FileAccess.Read);// Read an existing file.
            //// Create a BinaryWriter object passing in the FileStream object.
            //BinaryReader reader2 = new BinaryReader(sourceFile2);
            //bool boolValue = reader2.ReadBoolean();
            //byte byteValue = reader2.ReadByte();
            //byte[] byteArrayValue = reader2.ReadBytes(4);
            //char charValue = reader2.ReadChar();
            //char[] charArrayValue = reader2.ReadChars(4);
            //decimal decimalValue = reader2.ReadDecimal();
            //double doubleValue = reader2.ReadDouble();
            //float floatValue = reader2.ReadSingle();
            //int intValue = reader2.ReadInt32();
            //long longValue = reader2.ReadInt64();
            //sbyte sbyteValue = reader2.ReadSByte();
            //short shortValue = reader2.ReadInt16();
            //string stringValue = reader2.ReadString();
            //uint unintValue = reader2.ReadUInt32();
            //ulong ulongValue = reader2.ReadUInt64();
            //ushort ushortValue = reader2.ReadUInt16();
            //// Close the streams to release any file handles.
            //reader2.Close();
            //sourceFile2.Close();
            #endregion
        }
    }
}