using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;

namespace Wiaoj.ECommerce.CatalogDiscoveryService.WebAPI.Repositories;
internal sealed class ElasticsearchCatalogItemRepository {
    private readonly ElasticsearchClient elasticClient;

    public ElasticsearchCatalogItemRepository() {
        this.elasticClient = new ElasticsearchClient(new Uri("elastic-uri"));
    }

    public async Task<CatalogItem?> GetByIdAsync(String id) {
        GetResponse<CatalogItem> response = await this.elasticClient.GetAsync<CatalogItem>(id);
        return response.Source;
    }

    public async Task<IReadOnlyCollection<CatalogItem>> SearchAsync(Int32 page, Int32 size) {
        Action<SearchRequestDescriptor<CatalogItem>> configureRequest = searchRequest => searchRequest.Index("catalog_items_index")
                                                                                                  .From(page)
                                                                                                  .Size(size);
        SearchResponse<CatalogItem> response = await this.elasticClient.SearchAsync<CatalogItem>(configureRequest);
        return response.Documents;
    }

    public async Task<IReadOnlyCollection<CatalogItem>> SearchAsync(Query criteria) {
        Action<SearchRequestDescriptor<CatalogItem>> configureRequest = searchRequest => searchRequest.Index("catalog_items_index")
                                                                                                  .From(0)
                                                                                                  .Size(16)
                                                                                                  .Query(criteria);
        SearchResponse<CatalogItem> response = await this.elasticClient.SearchAsync<CatalogItem>(configureRequest);
        return response.Documents;
    }

    public async Task IndexAsync(CatalogItem product) {
        await this.elasticClient.IndexAsync(product);
    }
}
public class CatalogItem {
    public String Name { get; private set; }
    public String Description { get; private set; }
    public String Price { get; private set; }
    public String CategoryId { get; private set; }
    public String Sku { get; private set; }
    public Int32 StockQuantity { get; private set; }
    public Boolean IsAvailable { get; private set; }
}