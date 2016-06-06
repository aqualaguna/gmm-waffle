using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLIB
{
    public class condition
    {

        public string first, second;
        public Logic logicOP;
        public opCondition op;
        public string logicConvert(Logic l)
        {
            switch (l)
            {
                case Logic.and:
                    return " and ";
                case Logic.or:
                    return " or ";
                case Logic.none:
                    return "";
            }
            return "";
        }
        public condition(string a, opCondition b, string c, Logic t)
        {
            first = a;
            second = c;
            logicOP = t;
            op = b;
        }
        public condition(string a, opCondition b, string c)
        {
            first = a;
            second = c;
            logicOP = Logic.none;
            op = b;
        }
        public condition(string a, string c, Logic t)
        {
            first = a;
            second = c;
            this.logicOP = t;
            op = opCondition.eq;
        }
        public string toString()
        {
            return this.first + operatorConv(this.op) + this.second + logicConvert(this.logicOP);
        }
        public string operatorConv(opCondition e)
        {
            switch (e)
            {
                case opCondition.eq:
                    return "=";
                case opCondition.lte:
                    return "<=";
                case opCondition.gte:
                    return ">=";
                case opCondition.gt:
                    return ">";
                case opCondition.lt:
                    return "<";
                case opCondition.ne:
                    return "!=";
                case opCondition.like:
                    return " LIKE ";
                default: return "=";
            }

        }
    };
}
