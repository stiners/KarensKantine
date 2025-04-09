using Azure;
using Azure.Data.Tables;
using IBAS_kantine.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IBAS_kantine.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<MenuItem> MenuItems = new List<MenuItem>();
    
    public IndexModel(ILogger<IndexModel> logger) // Constructor
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var tableName = "KarensKantine";
        var connectionString =
            "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=ibaskantine7819;AccountKey=uElS/bVs3DHmTh98AwAS+xdbXtEUV21WJ+RRyBiJEXIVKqjNDiEF4ZFh8sC/QyqmfJdlIyAIgi9E+AStD2gnFw==;BlobEndpoint=https://ibaskantine7819.blob.core.windows.net/;FileEndpoint=https://ibaskantine7819.file.core.windows.net/;QueueEndpoint=https://ibaskantine7819.queue.core.windows.net/;TableEndpoint=https://ibaskantine7819.table.core.windows.net/";
    
        TableClient tableClient = new TableClient(connectionString, tableName);
        
        Pageable<TableEntity> entities = tableClient.Query<TableEntity>();

        foreach (var entity in entities)
        {
            var menuItem = new MenuItem()
            {
                PartitionKey = entity.PartitionKey,
                RowKey = entity.RowKey,
                KoldRet = entity.GetString("KoldRet"), // searching the TableEntity 'dictionary'
                VarmRet = entity.GetString("VarmRet")
            };
            MenuItems.Add(menuItem);
        }
    }
}
