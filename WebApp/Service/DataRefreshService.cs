using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.HostedService;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;
using WebApp;
using WebApp.models;
using System.Security.Cryptography.X509Certificates;

public class DataRefreshService : HostedService
{
    List<Cidade> cidades;
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        cidades = new List<Cidade>();
        
        while (!cancellationToken.IsCancellationRequested)
        
        {
            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);

            const string APPID = "c44d37818a595aaa2ef62325416db0e7";
            

            var idCidades = new List<string> { "Florianopolis", "Sao Paulo", "Rio de Janeiro" };

            int count = 0;

            double temperatura = 0;

            System.Collections.IList list = idCidades;

            for (int i = 0; i < list.Count; i++)
            {


                using (WebClient web = new WebClient())

                {
                    string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", idCidades[i], APPID);
                    var json = web.DownloadString(url);

                    var result = JsonConvert.DeserializeObject<InfTemp.root>(json);

                    InfTemp.root output = result;

                    temperatura = output.main.Temp;

                }

               
                cidades.Add( new Cidade( idCidades[i], temperatura, DateTime.Now));
                i = count++;
            }
       }  
    }
    public Cidade GetCidade(String Name)
    {
        return this.cidades.Where(m => m.Name == Name).FirstOrDefault();
    }

    public List<Cidade> GetCidades()
    {
        return this.cidades.ToList();
    }
}

