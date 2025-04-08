namespace IBAS_kantine.Models;

public class MenuItem
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string KoldRet { get; set; }
    public string VarmRet { get; set; }
}