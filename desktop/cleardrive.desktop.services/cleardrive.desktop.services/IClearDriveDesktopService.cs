//using desktop.cleardrive.desktop.models;
using Models;

namespace desktop.cleardrive.desktop.services
{
	public interface IClearDriveDesktopService
	{
        public Task<List<Position>> SelectAll();
        public Task<string> InsertAsync(Position position);
        public Task<string> DeleteAsync(Guid guid);
    }
}