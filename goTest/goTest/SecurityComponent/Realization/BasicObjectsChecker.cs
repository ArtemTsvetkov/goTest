using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Configs;
using goTest.SecurityComponent.Exceptions;
using goTest.SecurityComponent.Interfaces;
using goTest.Testing.Types;
using goTest.Testing.Types.BasicDBObjects;
using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.BasicDBObjects.Realization;
using goTest.Testing.Types.BasicDBObjects.Realization.Attributes;
using goTest.Testing.Types.BasicDBObjects.Realization.Objects;
using goTest.Testing.Types.BasicDBObjects.Realization.Types;
using goTest.Testing.Types.Unswer.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Realization
{
    class BasicObjectsChecker
    {
        List<DbObject> attrs;
        List<DbObject[]> objects;
        List<DbObject> types;
        List<DbObject[]> schemas;
        SecurityQueryConfigurator queryConfigurator;

        public BasicObjectsChecker(SecurityQueryConfigurator queryConfigurator)
        {
            this.queryConfigurator = queryConfigurator;
            attrs = new List<DbObject>();
            attrs.Add(new Password());
            attrs.Add(new Sult());
            attrs.Add(new ContentAttr());
            attrs.Add(new DevelopStatusAttr());
            attrs.Add(new QuestionsCountAttr());
            attrs.Add(new QuestionsTypeAttr());
            attrs.Add(new RequiredQuestionsAttr());
            attrs.Add(new UnswersTypeAttr());

            types = new List<DbObject>();
            types.Add(new DevelopStatusType());
            types.Add(new User());
            types.Add(new QuestionTType());
            types.Add(new Testing.Types.BasicDBObjects.Realization.QuestionType());
            types.Add(new SchemaType());
            types.Add(new SubjectType());
            types.Add(new TestType());
            types.Add(new UnswerTType());
            types.Add(new UnswerType());

            objects = new List<DbObject[]>();
            objects.Add(new DbObject[2] {new MainSchema(), new SchemaType()});
            objects.Add(new DbObject[2] {new Admin(), new User()});
            objects.Add(new DbObject[2] {new InApproveStatus(), new DevelopStatusType()});
            objects.Add(new DbObject[2] {new MultiplyAnswer(), new QuestionTType()});
            objects.Add(new DbObject[2] {new RightUnswer(), new UnswerTType()});
            objects.Add(new DbObject[2] {new SingleAnswer(), new QuestionTType()});
            objects.Add(new DbObject[2] {new Unswer(), new UnswerTType()});

            schemas = new List<DbObject[]>();
            schemas.Add(new DbObject[3] {new MainSchema(),new TestType(), new QuestionsCountAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new TestType(),
                new RequiredQuestionsAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new Testing.Types.BasicDBObjects.
                Realization.QuestionType(), new QuestionsTypeAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new Testing.Types.BasicDBObjects.
                Realization.QuestionType(), new ContentAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new User(), new Password()});
            schemas.Add(new DbObject[3] { new MainSchema(), new User(), new Sult()});
            schemas.Add(new DbObject[3] { new MainSchema(), new UnswerType(), new ContentAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new UnswerType(), new UnswersTypeAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new SubjectType(), new DevelopStatusAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new TestType(), new DevelopStatusAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new Testing.Types.BasicDBObjects.
                Realization.QuestionType(), new DevelopStatusAttr()});
            schemas.Add(new DbObject[3] { new MainSchema(), new UnswerType(), new DevelopStatusAttr()});
        }

        public void check()
        {
            List<string> result = new List<string>();
            
            for (int i=0; i<attrs.Count; i++)
            {
                try
                {
                    int id = DataSetConverter.fromDsToSingle.toInt.convert(
                        SqlLiteSimpleExecute.execute(getQueryForGettingAttrId(
                        attrs.ElementAt(i).getName())));
                }
                catch(СonversionError ex)
                {
                    throw new NotEnoughBasicObjects(attrs.ElementAt(i).getName());
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                try
                {
                    int id = DataSetConverter.fromDsToSingle.toInt.convert(
                        SqlLiteSimpleExecute.execute(getQueryForGettingObjectId(
                        objects.ElementAt(i)[0], objects.ElementAt(i)[1])));
                }
                catch (СonversionError ex)
                {
                    throw new NotEnoughBasicObjects(objects.ElementAt(i)[0].getName()+" "+
                        objects.ElementAt(i)[0].getName());
                }
            }
            for (int i = 0; i < types.Count; i++)
            {
                try
                {
                    int id = DataSetConverter.fromDsToSingle.toInt.convert(
                        SqlLiteSimpleExecute.execute(getQueryForGettingTypeId(
                        types.ElementAt(i).getName())));
                }
                catch (СonversionError ex)
                {
                    throw new NotEnoughBasicObjects(types.ElementAt(i).getName());
                }
            }
            for (int i = 0; i < schemas.Count; i++)
            {
                try
                {
                    int count = DataSetConverter.fromDsToSingle.toInt.convert(
                        SqlLiteSimpleExecute.execute(getCountStringFromSchemas(
                        schemas.ElementAt(i)[0], schemas.ElementAt(i)[1], schemas.ElementAt(i)[2])));
                    if(count == 0)
                    {
                        throw new СonversionError();
                    }
                }
                catch (СonversionError ex)
                {
                    throw new NotEnoughBasicObjects(schemas.ElementAt(i)[0].getName() + " " +
                        schemas.ElementAt(i)[1].getName()+" "+schemas.ElementAt(i)[2].getName());
                }
            }
            //Check admin
            int adminCount = DataSetConverter.fromDsToSingle.toInt.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.checkExistAdmin()));
            if (adminCount == 0)
            {
                throw new AdminIsNotExist();
            }
        }

        private string getQueryForGettingObjectId(DbObject objectName, DbObject objectType)
        {
            return "SELECT id FROM Objects WHERE name ='" + objectName.getName() + "' AND type=(" +
                getQueryForGettingTypeId(objectType.getName()) + ")";
        }

        private string getQueryForGettingTypeId(string name)
        {
            return "SELECT id FROM Types WHERE Name='" + name + "'";
        }

        private string getQueryForGettingAttrId(string attrName)
        {
            return "SELECT id FROM Attributes WHERE Name='" + attrName + "'";
        }

        private string getCountStringFromSchemas(DbObject objectId, DbObject typeId, 
            DbObject attrId)
        {
            return "SELECT COUNT(*) FROM Schemas WHERE id=(" + 
                getQueryForGettingObjectId(objectId, DbTypes.schema) + ") AND type_id=(" +
                getQueryForGettingTypeId(typeId.getName()) + 
                ") AND attr_id=(" + getQueryForGettingAttrId(attrId.getName())+")";
        }
    }
}
