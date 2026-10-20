using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace AIDocumentReader.Components.Pages
{
    public partial class Reader
    {
        [Inject]
        private IWebHostEnvironment Env { get; set; }

        string textArea = "Results will load here";
        private const long maxFileSize = 50 * 1024 * 1024;
        private string message = "";
        private string filename = "";

        protected override async Task OnInitializedAsync()
        {
           
        }

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var file = e.File;
            var name = file.Name;
            var ext = Path.GetExtension(name);

            var newName = Guid.NewGuid().ToString();
            var newLocation = Path.Combine(Env.WebRootPath, "temp");
            var newLocationPath = Path.Combine(newLocation, newName + ext);
            using var openStream = file.OpenReadStream(maxFileSize);

            await using var fs = new FileStream(newLocationPath, FileMode.Create);
        }

    }
}
