--+ README
module is a collection of related functions, types and teypclasses.. 

Having code split up into several modules has quite a lot of advantages. If a module is generic enough, the functions it exports can be used in a multitude of different programs. 

--+ resources

http://learnyouahaskell.com/modules


--+ modules
1). first we introduce the Geometry.hs file, which is a glob class with every function in it
  - module load 
      import Geometry
2). then we organize the Geometry.hs into hierarchical.structure 
  - module load 
      import Geometry.Sphere
    or 
      import Geometry.Sphere as Sphere
      import Geometry.Cuboid as Cuboid
      import Geometry.Cube as Cube
