using MyGym.BusinessLogic.ViewModels.TrainerViewModels;

namespace MyGym.BusinessLogic.Services.Trainers
{
    public interface ITrainerService
    {
        Task<TrainerDetailsVM?> getTrainerDetails(int id);
        Task<IEnumerable<TrainerListVM>> GetTrainersAsync();
        Task CreateTrainerAsync(CreateTrainerVM _createdTrainer);
        Task<EditTrainerVM?> getEditTrainerAsync(int id);
        Task UpdateTrainerAsync(int id, EditTrainerVM trainerVM);
        Task<bool?> DeleteTrainer(int id);
        Task<bool> ExistsAsync(int id);
    }
}
