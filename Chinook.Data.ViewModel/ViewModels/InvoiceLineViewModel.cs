using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Chinook.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Chinook.Data
{
    public partial class InvoiceLineViewModel : ZViewBase<InvoiceLineViewModel, InvoiceLineDTO, InvoiceLine>
    {
        #region Properties
        
        [Display(Name = "PropertyInvoiceLineId", ResourceType = typeof(InvoiceLineResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int InvoiceLineId { get; set; }
        
        [Display(Name = "PropertyInvoiceId", ResourceType = typeof(InvoiceLineResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int InvoiceId { get; set; }
        
        [Display(Name = "PropertyTrackId", ResourceType = typeof(InvoiceLineResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int TrackId { get; set; }
        
        [Display(Name = "PropertyUnitPrice", ResourceType = typeof(InvoiceLineResources))]
        [DisplayFormat(DataFormatString = "{0:f2}", ApplyFormatInEditMode = true)]
        [Range(0.01, Double.MaxValue)]
        [Required]
        public virtual decimal UnitPrice { get; set; }
        
        [Display(Name = "PropertyQuantity", ResourceType = typeof(InvoiceLineResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int Quantity { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string InvoiceLookupText { get; set; } // InvoiceId

        public virtual string TrackLookupText { get; set; } // TrackId
    
        #endregion Associations FK

        #region Properties ZViewBase

        public override string LookupText { get; set; }

        #endregion Properties ZViewBase

        #region Methods
        
        public InvoiceLineViewModel()
        {
            InvoiceLineId = 1;
        }
        
        public InvoiceLineViewModel(
            int invoiceLineId,
            int invoiceId,
            int trackId,
            decimal unitPrice,
            int quantity,
            string invoiceLookupText = null,
            string trackLookupText = null
        )
            : this()
        {
            InvoiceLineId = invoiceLineId;
            InvoiceId = invoiceId;
            TrackId = trackId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            InvoiceLookupText = invoiceLookupText;
            TrackLookupText = trackLookupText;
        }

        public InvoiceLineViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public InvoiceLineViewModel(IZDTOBase<InvoiceLineDTO, InvoiceLine> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<InvoiceLineViewModel, InvoiceLineDTO> GetDTOSelector()
        {
            return x => new InvoiceLineDTO
            {
                InvoiceLineId = x.InvoiceLineId,
                InvoiceId = x.InvoiceId,
                TrackId = x.TrackId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                InvoiceLookupText = x.InvoiceLookupText,
                TrackLookupText = x.TrackLookupText,
                LookupText = x.LookupText
            };
        }

        public override Func<InvoiceLineDTO, InvoiceLineViewModel> GetViewSelector()
        {
            return x => new InvoiceLineViewModel
            {
                InvoiceLineId = x.InvoiceLineId,
                InvoiceId = x.InvoiceId,
                TrackId = x.TrackId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                InvoiceLookupText = x.InvoiceLookupText,
                TrackLookupText = x.TrackLookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                InvoiceLineDTO dto = new InvoiceLineDTO(data);
                InvoiceLineViewModel view = (new List<InvoiceLineDTO> { (InvoiceLineDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<InvoiceLineDTO, InvoiceLine> dto)
        {
            if (dto != null)
            {
                InvoiceLineViewModel view = (new List<InvoiceLineDTO> { (InvoiceLineDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<InvoiceLineDTO, InvoiceLine> ToDTO()
        {
            return (new List<InvoiceLineViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}