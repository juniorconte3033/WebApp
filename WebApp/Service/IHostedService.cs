using System.Collections.Generic;
using WebApp.models;

namespace WebApp.Service
{
    public interface IHostedService
    {
        List<Cidade> GetCidades();
        Cidade GetCidade(string Name);
    }
}
