using Scorpion.Extensions.Serializers.Abstractions;
using Scorpion.Extensions.Serializers.EPPlus.Extensions;
using Scorpion.Extensions.Translations.Abstractions;
using System.Data;

namespace Scorpion.Extensions.Serializers.EPPlus.Services;

public class EPPlusExcelSerializer : IExcelSerializer
{
    private readonly ITranslator _translator;

    public EPPlusExcelSerializer(ITranslator translator)
    {
        _translator = translator;
    }

    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(_translator, sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>(_translator);
}
