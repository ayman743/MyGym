using MyGym.BusinessLogic.Exceptions;
using MyGym.BusinessLogic.ViewModels.MemberViewModels;
using MyGym.DataAccess.Models;
using MyGym.DataAccess.Repositories.Generic;
using MyGym.DataAccess.Repositories.Members;

namespace MyGym.BusinessLogic.Services.Members
{
    public class MemberService(IMemberRepository repository,IGenericRepository<Booking> _bookingRepo) : IMemberService
    {
        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AnyAsync(m => m.Id == id);
        }


        public async Task<EditMemberVm?> GetUpdateMember(int id)
        {
            var member = await repository.GetByIdAsync(id);
            if (member == null)
            {
                return null;
            }
            var EditMemberVm = new EditMemberVm()
            {
                BuildingNumber = member!.Address.BuildingNumber,
                City = member.Address.City,
                Email = member.Email,
                Name = member.Name,
                Phone = member.Phone,
                Street = member.Address.Street
            };
            return EditMemberVm;
        }



        public async Task UpdateMember(int id,EditMemberVm editMemberVm)
        {
            {
                var errors = new Dictionary<string, string>();
                var EmailExists = await repository.AnyAsync(m => m.Email == editMemberVm.Email && m.Id != id);
                var PhoneExists = await repository.AnyAsync(m => m.Phone == editMemberVm.Phone && m.Id != id);
                var member = await repository.GetByIdAsync(id);
                if (member == null)
                {
                    errors.Add("ErrorMessage","Member not found");
                }
                
                if (EmailExists)
                {
                    errors.Add("Email", "Email is already exists");
                }
                if (PhoneExists)
                {
                    errors.Add("Phone", "Phone is already exists");
                }
                if (errors.Any())
                {
                    throw new ValidationException(errors);
                }
                member!.Address.BuildingNumber = editMemberVm.BuildingNumber;
                member.Address.City = editMemberVm.City;
                member.Address.Street = editMemberVm.Street;
                member.Email = editMemberVm.Email;
                member.Phone = editMemberVm.Phone;
                await repository.SaveChangesAsync();

            }
        }



        public async Task<bool?> DeleteMember(int id)
        {
            var member = await repository.GetByIdAsync(id);

            if (member == null)
            {
                return null;
            }

            var hasActiveBookings = await _bookingRepo.
                AnyAsync(b => b.MemberId == id
                        && b.Session.EndDate>DateTime.Now);


            if (hasActiveBookings)
            {
                return false;
            }

            repository.Delete(member);
            await repository.SaveChangesAsync();

            return true;
        }


        public async Task<HealthRecordVm?> GetMemberHealthRecord(int id)
        {
            var member = await repository.GetHealthRecordByMemberIdAsync(id);
            if (member == null)
            {
                throw new Exception("Member Not Found");
            }
            if (member.HealthRecord == null)
            {
                throw new Exception("This Member Has No Health Record");
            }

            var HealthRecord = new HealthRecordVm()
            {
                BloodType = member.HealthRecord.BloodType,
                Height = member.HealthRecord.Height,
                Note = member.HealthRecord.Note,
                Weight = member.HealthRecord.Weight
            };
            return HealthRecord;
        }
        public async Task<MemberDetailsVm?> MemberDetails(int id)
        {
            var member = await repository.GetWithMembership(id);

            if (member == null)
            {
                return null;
            }
            var activeMembership = member.Memberships
                                         .FirstOrDefault();
            var memberdetailsVm = new MemberDetailsVm()
            {
                Id = id,
                Name = member.Name,
                Photo = member.Photo,
                Address = $"{member.Address.BuildingNumber} - {member.Address.Street} - {member.Address.City}",
                DateOfBirth = member.DateOfBirth,
                Email = member.Email,
                Phone = member.Phone,
                EndDate = activeMembership?.EndDate,
                StartDate = activeMembership?.StartDate,
                PlanName = activeMembership?.Plan.Name,
                Gender = member.Gender
            };
            return memberdetailsVm;
        }

        public async Task<IEnumerable<MemberVm>> GetAllMembersAsync(CancellationToken cancellationToken)
        {
            var members = await repository.GetAllAsync();
            if (members == null) return [];

            List<MemberVm> membersVm = [];
            foreach (var member in members)
            {
                var memberVm = new MemberVm()
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender,
                    Phone = member.Phone,
                    Photo = member.Photo
                };
                membersVm.Add(memberVm);
            }
            return membersVm;

        }


        public async Task CreateMemberAsync(CreateMemberVm memberVm)
        {
            var errors = new Dictionary<string, string>();

            var EmailExists = await repository.AnyAsync(m => m.Email == memberVm.Email);
            var PhoneExists = await repository.AnyAsync(m => m.Phone == memberVm.Phone);

            if (EmailExists)
            {
                errors.Add("Email", "Email is already exists");
            }
            if (PhoneExists)
            {
                errors.Add("Phone", "Phone is already exists");
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            var member = new Member()
            {
                Name = memberVm.Name,
                Email = memberVm.Email,
                Phone = memberVm.Phone,
                DateOfBirth = memberVm.DateOfBirth,
                Gender = memberVm.Gender,
                Photo = memberVm.Photo,
                Address = new Address()
                {
                    City = memberVm.City,
                    BuildingNumber = memberVm.BuildingNumber,
                    Street = memberVm.Street

                },
                HealthRecord = new HealthRecord()
                {
                    BloodType = memberVm.HealthRecord.BloodType,
                    Height = memberVm.HealthRecord.Height,
                    Weight = memberVm.HealthRecord.Weight,
                    Note = memberVm.HealthRecord.Note
                }
            };
         
            repository.Add(member);
            await repository.SaveChangesAsync();
        }
    }
}
