using Amazon.DynamoDBv2;
using Amazon.Lambda.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Shared.DataAccess;

namespace GetProducts;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IAmazonDynamoDB>(new AmazonDynamoDBClient());
        services.AddSingleton<ProductsDAO, DynamoDbProducts>();
    }
}