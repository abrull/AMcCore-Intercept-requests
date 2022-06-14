using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AmcInterception
{
    class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uri = request.RequestUri;
            if (uri.AbsoluteUri.Contains("/contact"))
            {
                return await Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(File.ReadAllText(@"C:\Users\abrull\Downloads\contact.json"))
                });
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
