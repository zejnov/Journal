using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Business.Services.ServicesInterfaces;
using MSJournal_Data.Repository;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Business.Services
{
    public class HomeworkServices : IHomeworkServices
    {
        private IHomeworkRepository _homeworkRepository;

        public HomeworkServices()
        {
            _homeworkRepository = new HomeworkRepository();
        }

        public HomeworkServices(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }


        public bool Add(HomeworkDto homeworkDto)
        {
            if (Exist(homeworkDto))
                return false;
            return _homeworkRepository.Add(DtoToEntity.HomeworkDtoToEntity(homeworkDto));
        }

        private bool Exist(HomeworkDto homeworkDto)
        {
            return _homeworkRepository
                .Exist(DtoToEntity.HomeworkDtoToEntity(homeworkDto));
        }

        private HomeworkDto Get(int id)
        {
            if (!Exist(new HomeworkDto() { Id = id }))
                return null;

            return EntityToDto.HomeworkEntityToDto
                (_homeworkRepository.Get(id));
        }

        public List<HomeworkDto> GetAll()
        {
            return _homeworkRepository
                .GetAll()
                .Select(EntityToDto.HomeworkEntityToDto)
                .ToList();
        }

        public List<HomeworkDto> GetHomework(StudentOnCourseDto studentOnCourseDto)
        {
            return _homeworkRepository
                .GetHomework(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
                .Select(EntityToDto.HomeworkEntityToDto)
                .ToList();
        }

        public bool RemoveHomework(HomeworkDto homework)
        {
            return _homeworkRepository
                .RemoveHomework(DtoToEntity.HomeworkDtoToEntity(homework));

        }
    }
}
