﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class SwitchExpression : IExpression
    {
        public IExpression SwitchExpr { get; private set; }
        public IExpression CaseExpr { get; private set; }

        public SwitchExpression(IExpression switchExpr, IExpression caseExpr)
        {
            SwitchExpr = switchExpr;
            CaseExpr = caseExpr;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("switch: ");
            SwitchExpr.AppendTo(sb);
            sb.AppendLine("{");
            CaseExpr.AppendTo(sb);
            sb.AppendLine("}");
        }
    }
}
