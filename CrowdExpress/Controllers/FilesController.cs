using AuthWebApi.Asset.Contract;
using AuthWebApi.Presentation;

namespace CrowdExpress.Controllers
{
    public class FilesController : ApiFilesController
    {
        public FilesController(IImageService image) : base(image)
        {}
    }
}
