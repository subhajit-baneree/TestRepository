using Honeywell.App.Business.Library.Enums;

namespace Honeywell.App.Business.Library.Interfaces
{
    public interface ITimeConverter
    {
        string ConvertToSelectedTimeZone(Timezone timeZone);
    }
}
