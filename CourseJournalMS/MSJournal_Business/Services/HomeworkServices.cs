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

        public bool CheckHomework(CourseDto courseDto)
        {
            foreach (var studentDto in courseDto.CourseStudentsList)
            {
                var studentHomeworkList = CourseServices
                    .GetStudentHomework(courseDto, studentDto.Id);

                studentDto.HomeworkPoints = 0;
                studentDto.HomeworkMaxPoints = 0;

                if (studentHomeworkList.Count != 0)
                {
                    foreach (var homework in studentHomeworkList)
                    {
                        studentDto.HomeworkPoints += homework.StudentPoints;
                        studentDto.HomeworkMaxPoints += homework.MaxPoints;
                    }
                    studentDto.HomeworkPerformance = 100.0d
                        * studentDto.HomeworkPoints / studentHomeworkList.Count;
                }

                if (studentDto.HomeworkPerformance >= courseDto.HomeworkThreshold)
                {
                    studentDto.HomeworkOk = true;
                }
                else
                {
                    studentDto.HomeworkOk = false;
                }
            }
            
            return true;
        }


    }
}
