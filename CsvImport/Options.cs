using CommandLine;

namespace CsvImport
{
    public class Options
    {
        [Option('p', "csvfilepath", Required = true, HelpText = "Path to CSV file to be imported")]
        public string CsvFilePath { get; set; }

        [Option('c', "configpath", Required = true, HelpText = "Path to folder containing appsettings.json configuration file")]

        public string ConfigPath { get; set; }
    }
}