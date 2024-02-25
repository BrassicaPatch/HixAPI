namespace HixAPI.Core;

public class MetricsData {
    public int ID {get; set;}
    public string MetricName { get; set; }
    public Dictionary<string, string> Labels { get; set; }
    public double Value { get; set; }

    public MetricsData(string name, Dictionary<string, string> labels, double value){
        MetricName=name;
        Labels=labels;
        Value=value;
    }
}