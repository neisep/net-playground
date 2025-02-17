using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using Wasmtime;

namespace PdfiumFunction
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            //var resourceStream = await Assembly.GetExecutingAssembly().ReadResourceAsync("main.wasm");
            var wasiConfig = new WasiConfiguration()
                .WithInheritedStandardInput()
                .WithInheritedStandardOutput()
                .WithInheritedStandardError()
                .WithInheritedEnvironment();
            using var config = new Config()
                .WithDebugInfo(true)
                .WithCraneliftDebugVerifier(true)
                .WithOptimizationLevel(OptimizationLevel.SpeedAndSize)
                .WithWasmThreads(true)
                .WithBulkMemory(true)
                .WithMultiMemory(true);


            using var engine = new Engine(config);
            using var linker = new Linker(engine);
            using var store = new Store(engine);
            using var module = Wasmtime.Module.FromFile(engine, "pdfium.wasm");

            store.SetWasiConfiguration(wasiConfig);
            linker.DefineWasi();

            //This is probobly how we define what code to execute and so on... should be easier i think...
            linker.Define("env", "abort", Function.FromCallback(store, () => Console.WriteLine("Hello from C#!")));


            linker.DefineModule(store, module);
            dynamic instance = linker.Instantiate(store, module);

            //instance.fib();

            //using var engine = new Engine();
            //using var module = Module.FromFile(engine, "pdfium.wasm");         

            //foreach (var item in module.Imports)
            //{

            //}

            //using var linker = new Linker(engine);
            //using var store = new Store(engine);

            //var wasi = new WasiConfiguration();

            //linker.DefineWasi();
            //store.SetWasiConfiguration(wasi);

            //using dynamic instance = linker.Instantiate(store, module);

            //instance.GetAction("");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
