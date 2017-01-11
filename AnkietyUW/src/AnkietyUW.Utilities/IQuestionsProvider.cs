using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Utilities
{
    public interface IQuestionsProvider
    {
        /// <summary>
        /// Zwraca 3 tablice z numerami pytan z odpowiednich kategorii pierwsza: emocje[9],Cwb[3],Ocb[3] 
        /// </summary>
        /// <param name="seriesNumber">numer serii</param>
        /// <returns></returns>
        int[][] QuestionsForSeriesNumber(int seriesNumber);
    }
}
