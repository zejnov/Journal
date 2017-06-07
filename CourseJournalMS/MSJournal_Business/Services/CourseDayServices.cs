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
    class CourseDayServices
    {
        public static bool Add(CourseDayDto courseDayDto)
        {
            if (Exist(courseDayDto))
                return false;
            return new CourseDayRepository()
                .Add(DtoToEntity.CourseDayDtoToEntity(courseDayDto));
        }

        private static bool Exist(CourseDayDto courseDayDto)
        {
            return new CourseDayRepository()
                .Exist(DtoToEntity.CourseDayDtoToEntity(courseDayDto));
        }

        private static CourseDayDto Get(int id)
        {
            if (!Exist(new CourseDayDto() { Id = id }))
                return null;

            return EntityToDto.CourseDayEntityToDto
                (new CourseDayRepository().Get(id));
        }

        public static List<CourseDayDto> GetAll()
        {
            return new CourseDayRepository()
                .GetAll()
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }
        
    }
}
