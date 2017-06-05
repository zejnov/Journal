using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Repository;

namespace MSJournal_Business.Services
{
    class HomeworkServices
    {
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

        public bool CheckAttendance(CourseDto courseDto, StudentDto studentDto)
        {




            return true;
        }


    }
}
