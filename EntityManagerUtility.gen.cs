using Unity.Collections;
using Unity.Entities;

namespace E7.EcsGadgets
{
    public partial class EntityManagerUtility
    {
        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public SCD1 GetSingleton<SCD1>(SCD1 filter1)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return em.GetSharedComponentData<SCD1>(eq.GetSingletonEntity());
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<SCD1>(SCD1 filter1)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<SCD1>(SCD1 filter1)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<SCD1>(SCD1 filter1)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<SCD1>(SCD1 filter1)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public SCD1 GetSingleton<SCD1>(bool nf)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return em.GetSharedComponentData<SCD1>(eq.GetSingletonEntity());
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<SCD1>(bool nf)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<SCD1>(bool nf)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<SCD1>(bool nf)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<SCD1>(bool nf)
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public SCD1 GetSingleton<SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return em.GetSharedComponentData<SCD1>(eq.GetSingletonEntity());
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public SCD1 GetSingleton<SCD1, SCD2>(bool nf1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return em.GetSharedComponentData<SCD1>(eq.GetSingletonEntity());
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<SCD1, SCD2>(bool nf1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<SCD1, SCD2>(bool nf1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<SCD1, SCD2>(bool nf1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<SCD1, SCD2>(bool nf1, SCD2 filter2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public SCD1 GetSingleton<SCD1, SCD2>(bool nf1, bool nf2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return em.GetSharedComponentData<SCD1>(eq.GetSingletonEntity());
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<SCD1, SCD2>(bool nf1, bool nf2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<SCD1, SCD2>(bool nf1, bool nf2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<SCD1, SCD2>(bool nf1, bool nf2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<SCD1, SCD2>(bool nf1, bool nf2)
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1>()
            where CD1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, CD6>()
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(SCD1 filter1)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, CD6, SCD1>(bool nf)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, SCD2 filter2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public CD1 GetSingleton<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingleton<CD1>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<CD1> ComponentDataArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToComponentDataArray<CD1>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public CD1[] Get<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToComponentDataArray<CD1>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public Entity[] Entities<CD1, CD2, CD3, CD4, CD5, CD6, SCD1, SCD2>(bool nf1, bool nf2)
            where CD1 : struct, IComponentData
            where CD2 : struct, IComponentData
            where CD3 : struct, IComponentData
            where CD4 : struct, IComponentData
            where CD5 : struct, IComponentData
            where CD6 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<CD1>(),
                ComponentType.ReadOnly<CD2>(),
                ComponentType.ReadOnly<CD3>(),
                ComponentType.ReadOnly<CD4>(),
                ComponentType.ReadOnly<CD5>(),
                ComponentType.ReadOnly<CD6>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }
    }
}