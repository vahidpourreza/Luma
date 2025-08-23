using Luma.Utilities.SoftwarePartDetector.DataModel;

namespace Luma.Utilities.SoftwarePartDetector.Publishers;

public interface ISoftwarePartPublisher
{
    Task PublishAsync(SoftwarePart softwarePart);
}
