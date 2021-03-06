﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class TryCatchFinallyExpression : IExpression
    {
        public IExpression TryExprs { get; private set; }
        public IExpression CatchVariable { get; private set; }
        public IExpression CatchExprs { get; private set; }
        public IExpression FinallyExprs { get; private set; }

        public TryCatchFinallyExpression(IExpression tryExprs, IExpression catchVariable, IExpression catchExprs, IExpression finallyExprs = null)
        {
            TryExprs = tryExprs;
            CatchVariable = catchVariable;
            CatchExprs = catchExprs;
            FinallyExprs = finallyExprs;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append("try: {");
            TryExprs.AppendTo(sb);
            sb.AppendLine("}");
            sb.Append("catch: ");
            CatchVariable.AppendTo(sb);
            sb.Append(" {");
            CatchExprs.AppendTo(sb);
            sb.AppendLine("}");
            if (FinallyExprs != null)
            {
                sb.Append("finally: {");
                FinallyExprs.AppendTo(sb);
                sb.AppendLine("}");
            }
        }
    }
}
