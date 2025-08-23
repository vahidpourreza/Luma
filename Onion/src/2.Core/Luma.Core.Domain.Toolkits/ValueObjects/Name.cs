using Luma.Core.Domain.Exceptions;
using Luma.Core.Domain.ValueObjects;
using Luma.Utilities.Resources;


namespace Luma.Core.Domain.Toolkits.ValueObjects
{

    public class Name : BaseValueObject<Name>
    {
        #region Properties
        public string Value { get; private set; }
        #endregion

        #region Constructors and Factories
        public static Name FromString(string value) => new Name(value);
        private Name(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidValueObjectStateException(LumaProjectValidationError.VALIDATION_ERROR_REQUIRED, LumaProjectTranslation.NAME);

            value = value.Trim();

            if (value.Length < LumaProjectConsts.NAME_MIN_LENGTH || value.Length > LumaProjectConsts.NAME_MAX_LENGTH)
                throw new InvalidValueObjectStateException(
                                                         LumaProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                         LumaProjectTranslation.NAME,
                                                         LumaProjectConsts.NAME_MIN_LENGTH.ToString(),
                                                         LumaProjectConsts.NAME_MAX_LENGTH.ToString()
                );


            Value = value;
        }
        private Name()
        {

        }
        #endregion


        #region Equality Check
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Operator Overloading
        public static explicit operator string(Name Name) => Name.Value;
        public static implicit operator Name(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value;

        #endregion
    }



}

