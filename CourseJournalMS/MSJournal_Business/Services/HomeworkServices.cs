using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Repository;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Business.Services
{
    public class HomeworkServices
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


        public static bool Add(HomeworkDto homeworkDto)
        {
            if (Exist(homeworkDto))
                return false;
            return new HomeworkRepository().Add(DtoToEntity.HomeworkDtoToEntity(homeworkDto));
        }

        private static bool Exist(HomeworkDto homeworkDto)
        {
            return new HomeworkRepository()
                .Exist(DtoToEntity.HomeworkDtoToEntity(homeworkDto));
        }

        private static HomeworkDto Get(int id)
        {
            if (!Exist(new HomeworkDto() { Id = id }))
                return null;

            return EntityToDto.HomeworkEntityToDto
                (new HomeworkRepository().Get(id));
        }

        public static List<HomeworkDto> GetAll()
        {
            return new HomeworkRepository()
                .GetAll()
                .Select(EntityToDto.HomeworkEntityToDto)
                .ToList();
        }

        public static List<HomeworkDto> GetHomework(StudentOnCourseDto studentOnCourseDto)
        {
            return new HomeworkRepository()
                .GetHomework(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
                .Select(EntityToDto.HomeworkEntityToDto)
                .ToList();
        }

        public static bool RemoveHomework(HomeworkDto homework)
        {
            return new HomeworkRepository()
                .RemoveHomework(DtoToEntity.HomeworkDtoToEntity(homework));

        }
        
        //********* do Moq'a **********
        public List<HomeworkDto> GetHomeworkTest(StudentOnCourseDto studentOnCourseDto)
        {
            return _homeworkRepository
                .GetHomework(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
                .Select(EntityToDto.HomeworkEntityToDto)
                .ToList();
        }
    }
}
