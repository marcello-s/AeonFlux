﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class AccessorExpression : IExpression
    {
        public IExpression Member { get; private set; }
        public IExpression AccessorExpr { get; private set; }

        public AccessorExpression(IExpression member, IExpression accessorExpr)
        {
            Member = member;
            AccessorExpr = accessorExpr;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("accessor: ");
            Member.AppendTo(sb);
            sb.Append("[");
            AccessorExpr.AppendTo(sb);
            sb.AppendLine("]");
        }
    }
}
