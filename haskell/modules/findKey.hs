findKey :: (Eq k) => k -> [(k,v)] -> Maybe v
findKey key = foldr (\(k,v) acc -> if key == k then Just v else acc) Nothing

--
findKey' :: (Eq k) => k -> [(k, v)] -> v
findKey' key xs = snd . head . filter (\(k, v) -> key == k) $ xs
