#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class ConditionalLoopExpression : IExpression
    {
        public IExpression ConditionalExpr { get; private set; }
        public IExpression Expr { get; private set; }
        public bool PostEvaluation { get; private set; }

        public ConditionalLoopExpression(IExpression conditionalExpr, IExpression expr, bool postEvaluation = false)
        {
            ConditionalExpr = conditionalExpr;
            Expr = expr;
            PostEvaluation = postEvaluation;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            if (PostEvaluation)
            {
                sb.Append("do-");
            }

            sb.Append("while: ");
            ConditionalExpr.AppendTo(sb);
            sb.AppendLine("{");
            Expr.AppendTo(sb);
            sb.AppendLine("}");
        }
    }
}
