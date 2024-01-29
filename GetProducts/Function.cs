using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.APIGatewayEvents;
using Shared.DataAccess;
using Shared.Models;

namespace GetProducts;

public class Function
{
    private readonly ProductsDAO dataAccess;

    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(Function))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(APIGatewayHttpApiV2ProxyRequest))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(APIGatewayHttpApiV2ProxyResponse))]
    public Function(ProductsDAO dataAccess)
    {
        this.dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
    }

    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Get, "/")]
    public async Task<ProductWrapper> FunctionHandler()
    {
        return await dataAccess.GetAllProducts();
    }
}