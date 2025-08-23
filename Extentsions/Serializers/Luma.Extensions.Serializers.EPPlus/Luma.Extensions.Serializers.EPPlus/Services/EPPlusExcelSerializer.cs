using Luma.Extensions.Serializers.Abstractions;
using Luma.Extensions.Serializers.EPPlus.Extensions;
using Luma.Extensions.Translations.Abstractions;
using System.Data;

namespace Luma.Extensions.Serializers.EPPlus.Services;


public class EPPlusExcelSerializer : IExcelSerializer
{
    private readonly ITranslator _translator;

    #region Constructor
    public EPPlusExcelSerializer(ITranslator translator)
    {
        _translator = translator;
    }
    #endregion


    #region Methods

    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(_translator, sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>(_translator);

    #endregion

}

