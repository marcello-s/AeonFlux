#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2016 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class ReturnExpression : IExpression
    {
        public IExpression Expr { get; private set; }

        public ReturnExpression(IExpression expr)
        {
            Expr = expr;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("return: ");
            if (Expr != null)
            {
                Expr.AppendTo(sb);
            }
        }
    }
}
