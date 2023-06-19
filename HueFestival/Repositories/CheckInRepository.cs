using HueFestival.Models;
using HueFestival.Repositories.IRepositories;

namespace HueFestival.Repositories
{
    public class CheckInRepository : Repository<Check_in>, ICheckInRepository
    {
        private readonly HueFestival_DbContext _context;
        public CheckInRepository(HueFestival_DbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Check_in>> danhSachCheckIn()
        {
            return await GetAllAsync();
        }

        public async Task<Check_in> Check_In(string QRcode)
        {
            var Check =  _context.ChiTiet_DatVes.FirstOrDefault(c => c.QRcode == QRcode);
            if (Check == null)
            {
                return null;
            }

            var existingCheckin =  _context.Check_ins.FirstOrDefault(c => c.IdDatVe == Check.IdDatVe);
            if (existingCheckin != null)
            {
                return null;
            }

            var checkin = new Check_in
            {
                NgayCheckIn = DateTime.Now,
                IdDatVe = Check.IdDatVe,
            };
            await PostAsync(checkin);
            return checkin;
        }
    }
}
