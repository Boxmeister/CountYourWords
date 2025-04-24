using CountYourWords.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CountYourWords.Services;
using CountYourWords.Configuration;

// Create Host
var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<FileSettings>(context.Configuration.GetSection("FileSettings"));

        services.AddSingleton<IFileReader, FileReader>();
        services.AddSingleton<ITextProcessor, TextProcessor>();
        services.AddSingleton<ISorter, Sorter>();
    })
    .Build();

// Resolve services
var processor = host.Services.GetRequiredService<ITextProcessor>();
//var result = processor.ProcessWords();

// Output result...
