using HixAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace HixAPI;
public class AppDbContext : DbContext {

    public AppDbContext() : base() { }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<MetricsData> MetricsDatas = null!;

    public async virtual Task<List<MetricsData>> GetMetricsAsync() {
        return await MetricsDatas
            .OrderBy(metric => metric.MetricName)
            .AsNoTracking()
            .ToListAsync();
    }

    public async virtual Task AddMetricAsync(MetricsData metric) {
        await MetricsDatas.AddAsync(metric);
        await SaveChangesAsync();
    }

    public async virtual Task DeleteAllMetricsAsync() {
        await MetricsDatas.ForEachAsync(m => Remove(m));
        await SaveChangesAsync();
    }

    public async virtual Task DeleteMetricAsync(int id) {
        var metric = await MetricsDatas.FindAsync(id);

        if (metric != null) {
            MetricsDatas.Remove(metric);
            await SaveChangesAsync();
        }
    }

    public void Initalize(){
        MetricsDatas.AddRange(new List<MetricsData> {
            new MetricsData("Metric1", new Dictionary<string, string> { { "Label1", "Value1" }, { "Label2", "Value2" } }, 123.45),
            new MetricsData("Metric2", new Dictionary<string, string> { { "Label3", "Value3" }, { "Label4", "Value4" } }, 67.89),
            new MetricsData("Metric3", new Dictionary<string, string> { { "Label5", "Value5" }, { "Label6", "Value6" } }, 987.65),
            new MetricsData("Metric4", new Dictionary<string, string> { { "Label7", "Value7" }, { "Label8", "Value8" } }, 543.21),
            new MetricsData("Metric5", new Dictionary<string, string> { { "Label9", "Value9" }, { "Label10", "Value10" } }, 321.09),
        });
        SaveChanges();
    }
}