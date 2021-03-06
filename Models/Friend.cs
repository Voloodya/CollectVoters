using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CollectVoters.Models
{
    [Table("friend")]
    public partial class Friend
    {
        [Key]
        [Column("Id_Friend")]
        public long IdFriend { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DisplayName("Фамилия")]
        [Column("Family_name", TypeName = "varchar(256)")]
        public string FamilyName { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [DisplayName("Имя")]
        [Column("Name_", TypeName = "varchar(256)")]
        public string Name { get; set; }
        [DisplayName("Отчество")]
        [Column("Patronymic_name", TypeName = "varchar(256)")]
        public string PatronymicName { get; set; }

        [DisplayName("Дата рожд.")]
        [Required(ErrorMessage = "Не указана дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column("Date_birth", TypeName = "date")]
        public DateTime? DateBirth { get; set; }
        [Required(ErrorMessage = "Не указан насел. п-т")]
        [DisplayName("Насел. пункт")]
        [Column("City_id")]
        public int? CityId { get; set; }
        [Required(ErrorMessage = "Не указана улица")]
        [DisplayName("Улица")]
        [Column(TypeName = "varchar(256)")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Не указан дом")]
        [DisplayName("Дом")]
        [Column(TypeName = "varchar(10)")]
        public string House { get; set; }
        [DisplayName("Квартира")]
        [Column(TypeName = "varchar(10)")]
        public string Apartment { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        [RegularExpression(@"[+]?[0-9]+"), StringLength(12)]
        [DisplayName("Тел. избирателя")]
        [Column(TypeName = "varchar(12)")]
        public string Telephone { get; set; }
        [DisplayName("Округ")]
        [Column("District_id")]
        public int? DistrictId { get; set; }
        [Required(ErrorMessage = "Не указан УИК")]
        [DisplayName("Избират. уч.")]
        [Column("Polling_station_id")]
        public int? PollingStationId { get; set; }
        [DisplayName("Организация")]
        [Column(TypeName = "varchar(256)")]
        public string Organization { get; set; }
        [DisplayName("Сфера деят-ти")]
        [Column("FieldActivity_id")]
        public int? FieldActivityId { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        [RegularExpression(@"[+]?[0-9]+"), StringLength(12)]
        [DisplayName("Тел. ответств-го")]
        [Column("Phone_number_responsible", TypeName = "varchar(12)")]
        public string PhoneNumberResponsible { get; set; }
        [DisplayName("Дата рег. на сайте")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column("Date_registration_site", TypeName = "date")]
        public DateTime? DateRegistrationSite { get; set; }
        [DisplayName("Дата голосования")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column("Voting_date", TypeName = "date")]
        public DateTime? VotingDate { get; set; }
        [DisplayName("Проголос-л")]
        [Column("Voter", TypeName = "TINYINT")]
        public bool Voter { get; set; }
        [DisplayName("Примечание")]
        [Column(TypeName = "varchar(256)")]
        public string Description { get; set; }
        [DisplayName("Агитатор")]
        [Column("User_id")]
        public long? UserId { get; set; }

        [DisplayName("Насел. п-т")]
        [ForeignKey(nameof(CityId))]
        [InverseProperty("Friends")]
        public virtual City City { get; set; }
        [DisplayName("Округ")]
        [ForeignKey(nameof(DistrictId))]
        [InverseProperty("Friends")]
        public virtual District District { get; set; }
        [DisplayName("Сфера деят-ти")]
        [ForeignKey(nameof(FieldActivityId))]
        [InverseProperty(nameof(Fieldactivity.Friends))]
        public virtual Fieldactivity FieldActivity { get; set; }
        [DisplayName("Участок")]
        [ForeignKey(nameof(PollingStationId))]
        [InverseProperty("Friends")]
        public virtual PollingStation PollingStation { get; set; }
        [DisplayName("Агитатор")]
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Friends")]
        public virtual User User { get; set; }
    }
}
