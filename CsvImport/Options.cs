using CommandLine;
using Infrastructure.Integration.CSV.Enums;

namespace CsvImport
{
    public class Options
    {
        [Option('p', "csvfilepath", Required = true, HelpText = "Path to CSV file to be imported")]
        public string CsvFilePath { get; set; }

        [Option('c', "configpath", Required = true, HelpText = "Path to folder containing appsettings.json configuration file")]

        public string ConfigPath { get; set; }

        [Option('m', "mode", Required = false, HelpText = "Import mode: 0 = publication item (default), 1 = publication")]
        public ImportModeEnum ImportMode { get; set; }
    }
}