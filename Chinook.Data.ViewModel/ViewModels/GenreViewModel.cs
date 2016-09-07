using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Chinook.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Chinook.Data
{
    public partial class GenreViewModel : ZViewBase<GenreViewModel, GenreDTO, Genre>
    {
        #region Properties
        
        [Display(Name = "PropertyGenreId", ResourceType = typeof(GenreResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int GenreId { get; set; }
        
        [Display(Name = "PropertyName", ResourceType = typeof(GenreResources))]
        [StringLength(120)]
        public virtual string Name { get; set; }

        #endregion Properties

        #region Properties ZViewBase

        public override string LookupText { get; set; }

        #endregion Properties ZViewBase

        #region Methods
        
        public GenreViewModel()
        {
            GenreId = 1;
        }
        
        public GenreViewModel(
            int genreId,
            string name = null
        )
            : this()
        {
            GenreId = genreId;
            Name = name;
        }

        public GenreViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public GenreViewModel(IZDTOBase<GenreDTO, Genre> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<GenreViewModel, GenreDTO> GetDTOSelector()
        {
            return x => new GenreDTO
            {
                GenreId = x.GenreId,
                Name = x.Name,
                LookupText = x.LookupText
            };
        }

        public override Func<GenreDTO, GenreViewModel> GetViewSelector()
        {
            return x => new GenreViewModel
            {
                GenreId = x.GenreId,
                Name = x.Name,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                GenreDTO dto = new GenreDTO(data);
                GenreViewModel view = (new List<GenreDTO> { (GenreDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<GenreDTO, Genre> dto)
        {
            if (dto != null)
            {
                GenreViewModel view = (new List<GenreDTO> { (GenreDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<GenreDTO, Genre> ToDTO()
        {
            return (new List<GenreViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
