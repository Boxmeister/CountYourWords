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
        services.AddSingleton<TextProcessorHandler>();
    })
    .Build();


var handler = host.Services.GetRequiredService<TextProcessorHandler>();
var result = handler.ProcessText();
if (result != null)
{
    result.ForEach(w => Console.WriteLine($"{w.Word} {w.Count}"));

}