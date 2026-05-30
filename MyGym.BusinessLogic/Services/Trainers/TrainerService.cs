using MyGym.BusinessLogic.Exceptions;
using MyGym.BusinessLogic.ViewModels.TrainerViewModels;
using MyGym.DataAccess.Models;
using MyGym.DataAccess.Repositories.Generic;

namespace MyGym.BusinessLogic.Services.Trainers
{
    public class TrainerService(IGenericRepository<Trainer> _trainerRepository
        ,IGenericRepository<Session> _SessionRepository) : ITrainerService
    {
        public async Task<TrainerDetailsVM?> getTrainerDetails(int id)
        {
            var trainer=await _trainerRepository.GetByIdAsync(id);
            if(trainer == null)
            {
                return null;
            }
            var TrainerDetails = new TrainerDetailsVM()
            {
                Name = trainer.Name,
                Address = $"{trainer.Address.BuildingNumber} - {trainer.Address.Street} - {trainer.Address.City}",
                Phone = trainer.Phone,
                DateOfBirth = trainer.DateOfBirth,
                Email = trainer.Email,
                Specialties = $"{trainer.Specialty} Trainer"
            };
            return TrainerDetails;
        }


        public async Task<bool> ExistsAsync(int id)
        {
            return await _trainerRepository.AnyAsync(x => x.Id == id);
        }



        public async Task<bool?>DeleteTrainer(int id)
        {
            var trainer=await _trainerRepository.GetByIdAsync(id);
            
            var HasSession =await _SessionRepository.AnyAsync(s => s.TrainerId == id && s.EndDate>DateTime.Now);
            if (trainer == null)
            {
                return null;

            }
            if(HasSession)
            {
                return false;
            }
            _trainerRepository.Delete(trainer);
            await _trainerRepository.SaveChangesAsync();
            return true;
        }


        public async Task<EditTrainerVM?> getEditTrainerAsync(int id)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            if (trainer == null)
            {
                return null;
            }
            var trainerVm = new EditTrainerVM()
            {
                Name = trainer.Name,
                BuildingNumber = trainer.Address.BuildingNumber,
                City = trainer.Address.City,
                Street = trainer.Address.Street,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Specialties = trainer.Specialty
            };
            return trainerVm;
        }


        public async Task UpdateTrainerAsync(int id, EditTrainerVM trainerVM)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            var errors = new Dictionary<string, string>();
           
            if (trainer == null)
            {
                errors.Add("ErrorMessage", "Trainer Not Found");
                throw new ValidationException( errors);
            }
            bool EmailExists = await _trainerRepository.AnyAsync(t => t.Email == trainerVM.Email && t.Id != id);
            bool PhoneExists = await _trainerRepository.AnyAsync(t => t.Phone == trainerVM.Phone && t.Id != id);
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
            trainer!.Phone = trainerVM.Phone;
            trainer.Email = trainerVM.Email;
            trainer.Address.BuildingNumber = trainerVM.BuildingNumber!.Value;
            trainer.Address.City = trainerVM.City;
            trainer.Address.Street = trainerVM.Street;
            trainer.Specialty = trainerVM.Specialties!.Value;
            trainer.UpdatedAt = DateTime.Now;

            await _trainerRepository.SaveChangesAsync();

        }

        public async Task<IEnumerable<TrainerListVM>> GetTrainersAsync()
        {
            var trainers = await _trainerRepository.GetAllAsync();
            if (!trainers.Any())
            {
                return [];
            }
            List<TrainerListVM> trainerList = [];

            foreach (var trainer in trainers)
            {
                var trainerListVm = new TrainerListVM
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    Email = trainer.Email,
                    Phone = trainer.Phone,
                    Specialties = trainer.Specialty
                };

                trainerList.Add(trainerListVm);
            }

            return trainerList;
        }


        public async Task CreateTrainerAsync(CreateTrainerVM _createdTrainer)
        {
            var errors = new Dictionary<string, string>();
            bool EmailExists = await _trainerRepository.AnyAsync(t => t.Email == _createdTrainer.Email);
            bool PhoneExists = await _trainerRepository.AnyAsync(t => t.Phone == _createdTrainer.Phone);
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
            var trainer = new Trainer()
            {
                Name = _createdTrainer.Name,
                Email = _createdTrainer.Email,
                Phone = _createdTrainer.Phone,
                Gender = _createdTrainer.Gender!.Value,
                DateOfBirth = _createdTrainer.DateOfBirth,
                Address = new Address()
                {
                    BuildingNumber = _createdTrainer.BuildingNumber!.Value,
                    City = _createdTrainer.City,
                    Street = _createdTrainer.Street,
                },
                Specialty = _createdTrainer.Specialties!.Value,
            };
            _trainerRepository.Add(trainer);
            await _trainerRepository.SaveChangesAsync();
        }

    }
}
