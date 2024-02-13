package com.example.demo.repositories;


import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.example.demo.Models.Pepe;

@Repository
public interface UserRepository extends CrudRepository<Pepe, Long> {}