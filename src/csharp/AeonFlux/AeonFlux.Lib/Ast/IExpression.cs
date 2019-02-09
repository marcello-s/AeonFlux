#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal interface IExpression
    {
        R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope);
        void AppendTo(StringBuilder sb);
    }

}
